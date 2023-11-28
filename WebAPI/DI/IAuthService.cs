using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IAuthService
    {
        public Task<Admin?> LoginAdmin(AuthModel authModel);
        public Task<Client?> LoginClient(AuthModel authModel);
        public Task<Cynologist?> LoginCynologist(AuthModel authModel);
        public Task<Manager?> LoginManager(AuthModel authModel);

        public Task<RegistrationResult> RegisterAdmin(AuthModel authModel);
        public Task<RegistrationResult> RegisterClient(AuthModel authModel);
        public Task<RegistrationResult> RegisterCynologist(AuthModel authModel);
        public Task<RegistrationResult> RegisterManager(AuthModel authModel);

        public string GenerateJwtToken(int userId, string login, string role);

    }
}
