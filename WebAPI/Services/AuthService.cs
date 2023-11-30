using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class AuthService : ServiceBase, IAuthService
    {
        private readonly IHashService _hashService;

        public AuthService(CynologistPlusContext context, IHashService hashService) : base(context)
        {
            _hashService = hashService;
        }

        public string GenerateJwtToken(int userId, string login, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new byte[16];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(key);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, login),
                    new Claim("userId", $"{userId}"),
                    new Claim(ClaimTypes.Role, role)
                    // You can add here additional claims about user if it is needed
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Admin?> LoginAdmin(AuthModel authModel)
        {
            var admin = await _context.Admins
                .Include(admin => admin.AuthCredential)
                .Where(admin => admin.AuthCredential.Login == authModel.Login)
                .FirstOrDefaultAsync();
            if (admin == null)
                return null;
            if (_hashService.VerifyPassword(authModel.Password, admin.AuthCredential.PasswordHash!))
                return admin;
            return null;
        }

        public async Task<Client?> LoginClient(AuthModel authModel)
        {
            var client = await _context.Clients
                .Include(c => c.AuthCredential)
                .Where(c => c.AuthCredential.Login == authModel.Login)
                .FirstOrDefaultAsync();
            if (client == null)
                return null;
            if (_hashService.VerifyPassword(authModel.Password, client.AuthCredential.PasswordHash!))
                return client;
            return null;
        }

        public async Task<Cynologist?> LoginCynologist(AuthModel authModel)
        {
            var cynologist = await _context.Cynologists
                .Include(c => c.AuthCredential)
                .Where(c => c.AuthCredential.Login == authModel.Login)
                .FirstOrDefaultAsync();
            if (cynologist == null)
                return null;
            if (_hashService.VerifyPassword(authModel.Password, cynologist.AuthCredential.PasswordHash!))
                return cynologist;
            return null;
        }

        public async Task<Manager?> LoginManager(AuthModel authModel)
        {
            var manager = await _context.Managers
                .Include(c => c.AuthCredential)
                .Where(c => c.AuthCredential.Login == authModel.Login)
                .FirstOrDefaultAsync();
            if (manager == null)
                return null;
            if (_hashService.VerifyPassword(authModel.Password, manager.AuthCredential.PasswordHash!))
                return manager;
            return null;
        }

        public async Task<RegistrationResult> RegisterAdmin(AuthModel authModel)
        {
            if (await isLoginExists(authModel.Login))
                return RegistrationResult.LoginExists;

            AuthCredential authCredential = prepareCredentials(authModel.Login, authModel.Password);

            Admin admin = new Admin()
            {
                AuthCredential = authCredential
            };
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return RegistrationResult.Success;
        }

        public async Task<RegistrationResult> RegisterClient(AuthModel authModel)
        {
            if (await isLoginExists(authModel.Login))
                return RegistrationResult.LoginExists;

            AuthCredential authCredential = prepareCredentials(authModel.Login, authModel.Password);

            Client client = new Client()
            {
                AuthCredential = authCredential
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return RegistrationResult.Success;
        }

        public async Task<RegistrationResult> RegisterCynologist(AuthModel authModel)
        {
            if (await isLoginExists(authModel.Login))
                return RegistrationResult.LoginExists;

            AuthCredential authCredential = prepareCredentials(authModel.Login, authModel.Password);

            Cynologist cynologist = new Cynologist()
            {
                AuthCredential = authCredential
            };
            await _context.Cynologists.AddAsync(cynologist);
            await _context.SaveChangesAsync();
            return RegistrationResult.Success;
        }

        public async Task<RegistrationResult> RegisterManager(AuthModel authModel)
        {
            if (await isLoginExists(authModel.Login))
                return RegistrationResult.LoginExists;

            AuthCredential authCredential = prepareCredentials(authModel.Login, authModel.Password);

            Manager manager = new Manager()
            {
                AuthCredential = authCredential
            };
            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
            return RegistrationResult.Success;
        }


        private async Task<bool> isLoginExists(string login)
        {
            return await _context.AuthCredentials.AnyAsync(u => u.Login == login);
        }

        private AuthCredential prepareCredentials(string login, string password)
        {
            string hashedPassword = _hashService.HashPassword(password);
            AuthCredential authCredential = new AuthCredential()
            {
                Login = login,
                PasswordHash = hashedPassword
            };
            return authCredential;
        }
    }
}