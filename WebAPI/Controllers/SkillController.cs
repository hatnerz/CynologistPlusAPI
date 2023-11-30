using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] Skill skill)
        {
            CreationResult creationrResult = await _skillService.CreateSkill(skill);
            if (creationrResult == CreationResult.Success)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeSkill([FromBody] Skill dogSkill)
        {
            ModifyResult modifyResult = await _skillService.ChangeSkill(dogSkill);
            if (modifyResult == ModifyResult.Success)
                return Ok();
            if (modifyResult == ModifyResult.IncorrectData)
                return NotFound(new { message = "Skill not found" });
            return BadRequest();
        }

        [HttpDelete("{skillId}")]
        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            DeletingResult deletingResult = await _skillService.DeleteSkill(skillId);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return BadRequest(new { message = "Skill not found" });
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<Dog>>> GetSkills()
        {
            ICollection<Skill> skills = await _skillService.GetSkills();
            return Ok(skills);
        }

    }
}
