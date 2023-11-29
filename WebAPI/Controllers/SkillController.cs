using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SkillContoller : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillContoller(ISkillService skillService)
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

        [HttpPatch]
        public async Task<IActionResult> ChangeSkill([FromBody] Skill dogSkill)
        {
            ModifyResult modifyResult = await _skillService.ChangeSkill(dogSkill);
            if (modifyResult == ModifyResult.Success)
                return Ok();
            if (modifyResult == ModifyResult.IncorrectData)
                return NotFound(new { message = "Skill not found" });
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSkill(int skillId)
        {
            DeletingResult deletingResult = await _skillService.DeleteSkill(skillId);
            if (deletingResult == DeletingResult.Success)
                return Ok();
            if (deletingResult == DeletingResult.ItemNotFound)
                return BadRequest(new { message = "Skill not found" });
            return BadRequest();
        }

    }
}
