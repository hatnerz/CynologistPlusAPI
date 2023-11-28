using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // string result - JWT
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] AuthModel authModel)
        {
            if (authModel.Role.ToLower() == "admin")
            {
                Admin? admin = await _authService.LoginAdmin(authModel);
                if (admin == null)
                    return Unauthorized(new { message = "Incorrect credentials" });
                string token = _authService.GenerateJwtToken(admin.Id, admin.AuthCredential.Login!, authModel.Role);
                return Ok(new { token });
            }
            else if (authModel.Role.ToLower() == "cynologist")
            {
                Cynologist? cynologist = await _authService.LoginCynologist(authModel);
                if (cynologist == null)
                    return Unauthorized(new { message = "Incorrect credentials" });
                string token = _authService.GenerateJwtToken(cynologist.Id, cynologist.AuthCredential.Login!, authModel.Role);
                return Ok(new { token });
            }
            else if(authModel.Role.ToLower() == "client")
            {
                Client? client = await _authService.LoginClient(authModel);
                if (client == null)
                    return Unauthorized(new { message = "Incorrect credentials" });
                string token = _authService.GenerateJwtToken(client.Id, client.AuthCredential.Login!, authModel.Role);
                return Ok(new { token });
            }
            else if(authModel.Role.ToLower() == "manager")
            {
                Manager? manager = await _authService.LoginManager(authModel);
                if (manager == null)
                    return Unauthorized(new { message = "Incorrect credentials" });
                string token = _authService.GenerateJwtToken(manager.Id, manager.AuthCredential.Login!, authModel.Role);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Incorrect role" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel authModel)
        {
            RegistrationResult registrationResult;
            if (authModel.Role.ToLower() == "admin")
                registrationResult = await _authService.RegisterAdmin(authModel);
            else if (authModel.Role.ToLower() == "client")
                registrationResult = await _authService.RegisterClient(authModel);
            else if (authModel.Role.ToLower() == "manager")
                registrationResult = await _authService.RegisterManager(authModel);
            else if (authModel.Role.ToLower() == "cynologist")
                registrationResult = await _authService.RegisterCynologist(authModel);
            else
                return BadRequest(new { message = "Incorrect role" });

            switch (registrationResult)
            {
                case RegistrationResult.Success:
                    return Ok(new { message = $"{authModel.Role} registration successful" });
                case RegistrationResult.LoginExists:
                    return BadRequest(new { message = "Login already exists" });
            }
            return BadRequest();
        }

    }
}
