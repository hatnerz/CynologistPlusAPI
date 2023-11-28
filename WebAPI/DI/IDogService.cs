﻿using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IDogService
    {
        public Task<CreationResult> AddDog(Dog dog);

        public Task<ModifyResult> UpdateDog(Dog dog);

        public Task<CreationResult> AddSkillToDog(DogSkill dogSkill);

        public Task<ModifyResult> ChangeDogSkillWithLog(DogSkill newDogSkill);

        public Task<ICollection<Dog>> GetClientDogs(int clientId);

        public Task<ICollection<DogSkill>> GetCurrentDogSkills(int dogId);

        public Task<ICollection<DogSkillsLog>> GetDogSkillChange(int dogId, int skillId);
    }
}