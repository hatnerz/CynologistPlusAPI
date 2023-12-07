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
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraining([FromBody] Training training)
        {
            CreationResult creationResult = await _trainingService.CreateTraining(training);
            if (creationResult == CreationResult.Success)
                return Ok();
            if (creationResult == CreationResult.IncorrectRefference)
                return BadRequest("Incorrect cynologist or dog id");
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeTrainingData([FromBody] Training training)
        {
            ModifyResult modifyResult = await _trainingService.ChangeTrainingData(training);
            if (modifyResult == ModifyResult.Success)
                return Ok();
            if (modifyResult == ModifyResult.IncorrectData)
                return NotFound("Training not found");
            return BadRequest();
        }

        [HttpDelete("{trainingId}")]
        public async Task<IActionResult> DeleteTraining(int trainingId)
        {
            DeletingResult deletingResult = await _trainingService.DeleteTraining(trainingId);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return NotFound("Training center not found");
            return BadRequest();
        }

        [HttpGet("cynologist/{cynologistId}")]
        public async Task<ActionResult<List<Cynologist>>> GetCynologistTrainings(int cynologistId)
        {
            ICollection<Training> foundTrainings = await _trainingService.GetCynologistTrainings(cynologistId);
            return Ok(foundTrainings);
        }

        [HttpGet("dog/{dogId}")]
        public async Task<ActionResult<List<Cynologist>>> GetDogTrainings(int dogId)
        {
            ICollection<Training> foundTrainings = await _trainingService.GetCynologistTrainings(dogId);
            return Ok(foundTrainings);
        }
    }
}
