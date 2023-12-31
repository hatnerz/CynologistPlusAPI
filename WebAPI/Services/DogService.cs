﻿using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class DogService : ServiceBase, IDogService
    {
        private readonly ISkillService _skillService;

        public DogService(CynologistPlusContext context, ISkillService skillService) : base(context)
        {
            _skillService = skillService;
        }

        public async Task<CreationResult> AddDog(Dog dog)
        {
            if (dog.ClientId == null)
                return CreationResult.IncorrectData;
            var client = _context.Clients.Find(dog.ClientId);

            if (client == null)
                return CreationResult.IncorrectRefference;

            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();
            return CreationResult.Success;
        }

        public async Task<CreationResult> AddSkillToDog(DogSkill dogSkill)
        {
            bool isDogSkillAlreadyExists = await _context.DogSkills.AnyAsync(e => (e.SkillId == dogSkill.SkillId && e.DogId == dogSkill.DogId));
            if (isDogSkillAlreadyExists)
                return CreationResult.IncorrectData;
            if (dogSkill.SkillId == null || dogSkill.DogId == null)
                return CreationResult.IncorrectData;
            bool isDogExists = _context.Dogs.Any(e => e.Id == dogSkill.DogId);
            bool isSkillExists = _context.Skills.Any(e => e.Id == dogSkill.SkillId);
            if (!isDogExists && !isSkillExists)
                return CreationResult.IncorrectRefference;
            _context.DogSkills.Add(dogSkill);
            DogSkillsLog dogSkillsLogItem = _skillService.CreateDogSkillLogItem(dogSkill);
            _context.DogSkillsLogs.Add(dogSkillsLogItem);
            await _context.SaveChangesAsync();
            return CreationResult.Success;
        }

        public async Task<ModifyResult> ChangeDogSkillWithLog(DogSkill newDogSkill)
        {
            var foundDogSkill = await _context.DogSkills.FirstOrDefaultAsync(e => e.SkillId == newDogSkill.SkillId && e.DogId == newDogSkill.DogId);
            if (foundDogSkill == null)
                return ModifyResult.IncorrectRefference;
            DogSkillsLog dogSkillsLogItem = _skillService.CreateDogSkillLogItem(newDogSkill);
            foundDogSkill.Value = newDogSkill.Value;
            _context.DogSkillsLogs.Add(dogSkillsLogItem);
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }

        public async Task<DeletingResult> DeleteDog(int dogId)
        {
            var foundDog = _context.Dogs.Find(dogId);
            if (foundDog == null)
                return DeletingResult.ItemNotFound;
            _context.Dogs.Remove(foundDog);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public async Task<ICollection<Dog>> GetAllDogs()
        {
            var foundDogs = await _context.Dogs.ToListAsync();
            return foundDogs;
        }

        public async Task<ICollection<Dog>> GetClientDogs(int clientId)
        {
            var clientDogs = await _context.Dogs.Where(e => e.ClientId == clientId).ToListAsync();
            return clientDogs;
        }

        public async Task<ICollection<DogSkillOut>> GetCurrentDogSkills(int dogId)
        {
            var dogSkills = await _context.DogSkills.Where(e => e.DogId == dogId).Include(e => e.Skill).ToListAsync();
            List <DogSkillOut> dogSkillsMapped = new List<DogSkillOut>();
            foreach (var dogSkill in dogSkills)
            {
                DogSkillOut temp = new DogSkillOut();
                temp.Id = dogSkill.Id;
                temp.DogId = dogSkill.DogId;
                temp.Skill = dogSkill.Skill;
                temp.Value = dogSkill.Value;
                dogSkillsMapped.Add(temp);

            }
            return dogSkillsMapped;
        }

        public async Task<Dog?> GetDog(int id)
        {
            var foundDog = await _context.Dogs.FindAsync(id);
            return foundDog;
        }

        public async Task<ICollection<DogSkillsLog>> GetDogSkillChange(int dogId, int skillId)
        {
            var dogSkillsChange = await _context.DogSkillsLogs.Where(e => e.DogId == dogId && e.SkillId == skillId).OrderBy(e => e.ChangeDate).ToListAsync();
            return dogSkillsChange;
        }

        public async Task<ModifyResult> UpdateDog(Dog dog)
        {
            var foundDog = _context.Dogs.Find(dog.Id);
            if (foundDog == null)
                return ModifyResult.IncorrectData;
            foundDog.Name = dog.Name;
            foundDog.Breed = dog.Breed;
            foundDog.ClientId = dog.ClientId;
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }
    }
}
