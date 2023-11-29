using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class SkillService : ServiceBase, ISkillService
    {
        public SkillService(CynologistPlusContext context) : base(context)
        { }

        public async Task<ModifyResult> ChangeSkill(Skill skill)
        {
            var foundSkill = _context.Skills.Find(skill.Id);
            if (foundSkill == null)
                return ModifyResult.IncorrectData;
            foundSkill.MaxValue = skill.MaxValue;
            foundSkill.Name = skill.Name;
            foundSkill.Type = skill.Type;
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }

        public DogSkillsLog CreateDogSkillLogItem(DogSkill dogSkill)
        {
            DogSkillsLog dogSkillsLog = new DogSkillsLog();
            dogSkillsLog.SkillId = dogSkill.SkillId;
            dogSkillsLog.DogId = dogSkill.DogId;
            dogSkillsLog.CurrentValue = dogSkill.Value;
            dogSkillsLog.ChangeDate = DateTime.Now;
            return dogSkillsLog;
        }

        public async Task<CreationResult> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return CreationResult.Success;
        }

        public async Task<DeletingResult> DeleteSkill(int skillId)
        {
            var foundSkill = _context.Skills.Find(skillId);
            if (foundSkill == null)
                return DeletingResult.ItemNotFound;
            _context.Skills.Remove(foundSkill);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }
    }
}
