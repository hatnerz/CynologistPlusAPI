using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            Client? foundClient = await _clientService.GetClient(id);
            if (foundClient == null)
                return NotFound();
            return Ok(foundClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            DeletingResult deletingResult = await _clientService.DeleteClient(id);
            if(deletingResult == DeletingResult.Success)
                return Ok();
            if(deletingResult == DeletingResult.ItemNotFound)
                return NotFound();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeClientData([FromBody] Client client)
        {
            ModifyResult modifyResult = await _clientService.ChangeClientData(client);
            if (modifyResult == ModifyResult.Success)
                return Ok();
            if (modifyResult == ModifyResult.IncorrectData)
                return NotFound(new { message = "Client not found" });
            return BadRequest();
        }
    }
}
