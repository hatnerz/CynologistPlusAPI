using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface ISkillService
    {
        public Task<CreationResult> CreateSkill(Skill skill);
        public Task<ModifyResult> ChangeSkill(Skill skill);
        public Task<DeletingResult> DeleteSkill(int skillId);

        public DogSkillsLog CreateDogSkillLogItem(DogSkill dogSkill);
    }
}
