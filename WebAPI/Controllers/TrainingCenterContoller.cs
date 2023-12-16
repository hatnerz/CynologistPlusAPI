using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Migrations;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCenterController : ControllerBase
    {
        private readonly ITrainingCenterService _trainingCenterService;

        public TrainingCenterController(ITrainingCenterService trainingCenterService)
        {
            _trainingCenterService = trainingCenterService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainingCenter([FromBody] DogTrainingCenter trainingCenter)
        {
            CreationResult creationResult = await _trainingCenterService.AddTrainingCenter(trainingCenter);
            if (creationResult == CreationResult.Success)
                return Ok();
            return BadRequest();
        }

        [HttpPut("adress")]
        public async Task<IActionResult> ChangeTrainingCenterAdress([FromBody] Adress newAdress)
        {
            ModifyResult modifyResult = await _trainingCenterService.ChangeTrainingCenterAdress(newAdress.Id, newAdress);
            if (modifyResult == ModifyResult.Success)
                return Ok();
            if (modifyResult == ModifyResult.IncorrectData)
                return NotFound("Training center not found");
            return BadRequest();
        }

        [HttpDelete("{trainingCenterId}")]
        public async Task<IActionResult> DeleteTrainingCenter(int trainingCenterId)
        {
            DeletingResult deletingResult = await _trainingCenterService.DeleteTrainingCenter(trainingCenterId);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return NotFound("Training center not found");
            return BadRequest();
        }

        [HttpGet("cynologists/{trainingCenterId}")]
        public async Task<ActionResult<List<Cynologist>>> GetTrainingCenterCynologists(int trainingCenterId)
        {
            ICollection<Cynologist> trainingCenterCynologists = await _trainingCenterService
                .GetTrainingCenterCynologists(trainingCenterId);
            return Ok(trainingCenterCynologists);
        }

        [HttpGet]
        public async Task<ActionResult<List<DogTrainingCenter>>> GetTrainingCenters()
        {
            ICollection<DogTrainingCenter> allTrainingCenters = await _trainingCenterService.GetTrainingCenters();
            return Ok(allTrainingCenters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DogTrainingCenter>>> GetTrainingCenterById(int id)
        {
            DogTrainingCenter? dogTrainingCenter = await _trainingCenterService.GetTrainingCenter(id);
            if (dogTrainingCenter == null)
                return NotFound();
            return Ok(dogTrainingCenter);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<DogTrainingCenter>>> GetTrainingCentersWithFilters([FromBody] Adress adressFilter)
        {
            ICollection<DogTrainingCenter> allTrainingCenters = await _trainingCenterService
                .GetTrainingCentersWithFilters(adressFilter);
            return Ok(allTrainingCenters);
        }

        [HttpGet("manager/{managerId}")]
        public async Task<ActionResult<DogTrainingCenter>> GetManagerTrainingCenter(int managerId)
        {
            DogTrainingCenter? dogTrainingCenter = await _trainingCenterService.GetManagerTrainingCenter(managerId);
            if (dogTrainingCenter == null)
                return NotFound();
            return Ok(dogTrainingCenter);
        }
    }
}
