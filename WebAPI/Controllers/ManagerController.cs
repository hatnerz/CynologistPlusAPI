using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<ActionResult<Client>> GetManagers()
        {
            ICollection<Manager> foundManagers = await _managerService.GetManagers();
            return Ok(foundManagers);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManager([FromBody] Manager manager)
        {
            ModifyResult result = await _managerService.ModifyManager(manager);
            if (result == ModifyResult.Success)
            {
                return Ok();
            }
            if (result == ModifyResult.IncorrectData)
            {
                return BadRequest(new { message = "Incorrect manager id" });
            }
            if (result == ModifyResult.IncorrectRefference)
            {
                return BadRequest(new { message = "Incorrect dog training center id" });
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            DeletingResult deletingResult = await _managerService.DeleteManager(id);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return NotFound();
            return BadRequest();
        }
    }
}
