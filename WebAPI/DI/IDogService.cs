using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IDogService
    {
        public Task<CreationResult> AddDog(Dog dog);

        public Task<ModifyResult> UpdateDog(Dog dog);

        public Task<DeletingResult> DeleteDog(int dogId);

        public Task<CreationResult> AddSkillToDog(DogSkill dogSkill);

        public Task<ModifyResult> ChangeDogSkillWithLog(DogSkill newDogSkill);

        public Task<ICollection<Dog>> GetClientDogs(int clientId);

        public Task<ICollection<Dog>> GetAllDogs();

        public Task<ICollection<DogSkillOut>> GetCurrentDogSkills(int dogId);

        public Task<ICollection<DogSkillsLog>> GetDogSkillChange(int dogId, int skillId);

        public Task<Dog?> GetDog(int id);
    }
}
