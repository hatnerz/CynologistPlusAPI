using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDog([FromBody] Dog dog)
        {
            CreationResult result = await _dogService.AddDog(dog);
            if (result == CreationResult.Success)
                return Ok();
            if (result == CreationResult.IncorrectData)
                return BadRequest(new { message = "You must provide an client id" });
            if (result == CreationResult.IncorrectRefference)
                return BadRequest(new { message = "Incorrect client id" });
            return BadRequest();
        }

        [HttpPost("skill")]
        public async Task<IActionResult> AddSkillToDog([FromBody] DogSkill dogSkill)
        {
            CreationResult result = await _dogService.AddSkillToDog(dogSkill);
            if (result == CreationResult.Success)
                return Ok();
            if (result == CreationResult.IncorrectData)
                return BadRequest(new { message = "You must provide correct dog and skill ids or dog skill already exists" });
            if (result == CreationResult.IncorrectRefference)
                return BadRequest(new { message = "Incorred dog or skill ids" });
            return BadRequest();
        }

        [HttpPut("skill")]
        public async Task<IActionResult> ChangeDogSkill(DogSkill newDogSkill)
        {
            ModifyResult result = await _dogService.ChangeDogSkillWithLog(newDogSkill);
            if (result == ModifyResult.Success)
                return Ok();
            if (result == ModifyResult.IncorrectRefference)
                return BadRequest(new { message = "There must already be a record about this dog skill." });
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDog(Dog dog)
        {
            ModifyResult result = await _dogService.UpdateDog(dog);
            if (result == ModifyResult.Success)
                return Ok();
            if (result == ModifyResult.IncorrectData)
                return NotFound(new { message = "Dog not found" });
            return BadRequest();
        }

        [HttpDelete("{dogId}")]
        public async Task<IActionResult> DeleteDog(int dogId)
        {
            DeletingResult deletingResult = await _dogService.DeleteDog(dogId);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return NotFound(new { message = "Dog not found" });
            return BadRequest();
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<List<Dog>>> GetClientDogs(int clientId)
        {
            ICollection<Dog> clientDogs = await _dogService.GetClientDogs(clientId);
            return (List<Dog>)clientDogs;
        }

        [HttpGet("skill/{dogId}")]
        public async Task<ActionResult<List<DogSkillOut>>> GetCurrentDogSkills(int dogId)
        {
            ICollection<DogSkillOut> dogSkills = await _dogService.GetCurrentDogSkills(dogId);
            return (List<DogSkillOut>)dogSkills;
        }

        [HttpGet("skillchange/{dogId}/{skillId}")]
        public async Task<ActionResult<List<DogSkillsLog>>> GetDogSkillChange(int dogId, int skillId)
        {
            ICollection<DogSkillsLog> dogSkills = await _dogService.GetDogSkillChange(dogId, skillId);
            return (List<DogSkillsLog>)dogSkills;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            Dog? dog = await _dogService.GetDog(id);
            if (dog == null)
                return NotFound();
            else
                return dog;
        }
    }
}
