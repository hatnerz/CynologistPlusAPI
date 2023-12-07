using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class TrainingService : ServiceBase, ITrainingService
    {

        public TrainingService(CynologistPlusContext context) : base(context)
        { }

        public async Task<ModifyResult> ChangeTrainingData(Training training)
        {
            var foundTraining = _context.Trainings.Find(training.Id);
            if (foundTraining == null)
                return ModifyResult.IncorrectData;
                
            foundTraining.StartDate = training.StartDate;
            foundTraining.EndDate = training.EndDate;
            foundTraining.TrainingType = training.TrainingType;
            foundTraining.DogId = training.DogId;
            foundTraining.CynologistId = training.CynologistId;
            foundTraining.Comment = training.Comment;

            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }

        public async Task<CreationResult> CreateTraining(Training training)
        {
            bool isDogExists = await _context.Dogs.AnyAsync(e => e.Id == training.DogId);
            bool isCynologistExists = await _context.Cynologists.AnyAsync(e => e.Id == training.CynologistId);
            if (!isDogExists || !isCynologistExists)
                return CreationResult.IncorrectRefference;

            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();
            return CreationResult.Success;
        }

        public async Task<DeletingResult> DeleteTraining(int trainingId)
        {
            var foundTraining = _context.Trainings.Find(trainingId);
            if (foundTraining == null)
                return DeletingResult.ItemNotFound;
            _context.Trainings.Remove(foundTraining);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public async Task<ICollection<Training>> GetDogTrainings(int dogId)
        {
            var foundTrainings = await _context.Trainings.Where(e => e.DogId == dogId).ToListAsync();
            return foundTrainings;
        }

        public async Task<ICollection<Training>> GetCynologistTrainings(int cynologistId)
        {
            var foundTrainings = await _context.Trainings.Where(e => e.CynologistId == cynologistId).ToListAsync();
            return foundTrainings;
        }


        public Task<bool> PlanTrainings(ICollection<Training> training)
        {
            throw new NotImplementedException();
        }

    }
}