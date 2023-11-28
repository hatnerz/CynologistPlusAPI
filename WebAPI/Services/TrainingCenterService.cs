using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class TrainingCenterService : ServiceBase, ITrainingCenterService
    {
        public TrainingCenterService(CynologistPlusContext context) : base(context)
        { }

        public Task<ModifyResult> AddCynologistToTrainingCenter(int trainingCenterId, int cynologistId)
        {
            throw new NotImplementedException();
        }

        public Task<ModifyResult> AddManagerToTrainingCenter(int trainingCenterId, int managerId)
        {
            throw new NotImplementedException();
        }

        public async Task<CreationResult> AddTrainingCenter(DogTrainingCenter trainingCenter)
        {
            _context.DogTrainingCenters.Add(trainingCenter);
            await _context.SaveChangesAsync();
            return CreationResult.Success;
        }

        public async Task<ModifyResult> ChangeTrainingCenterAdress(int trainingCenterId, Adress adress)
        {
            var trainingCenter = _context.DogTrainingCenters.Find(trainingCenterId);
            if(trainingCenter == null)
                return ModifyResult.IncorrectData;

            trainingCenter.Adress = adress;
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }

        public async Task<DeletingResult> DeleteTrainingCenter(int trainingCenterId)
        {
            var trainingCenter = _context.DogTrainingCenters.Find(trainingCenterId);
            if (trainingCenter == null)
                return DeletingResult.ItemNotFound;

            _context.DogTrainingCenters.Remove(trainingCenter);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public async Task<ICollection<Cynologist>> GetTrainingCenterCynologists(int trainingCenterId)
        {
            var cynologists = await _context.Cynologists.Where(e => e.DogTrainingCenterId == trainingCenterId).ToListAsync();
            return cynologists;
        }

        public async Task<ICollection<DogTrainingCenter>> GetTrainingCenters()
        {
            var trainingCenters = await _context.DogTrainingCenters.ToListAsync();
            return trainingCenters;
        }

        public async Task<ICollection<DogTrainingCenter>> GetTrainingCentersWithFilters(Adress adressFilter)
        {
            // Base entity for for applying filters
            var trainingCentersQuerable = _context.DogTrainingCenters.AsQueryable();

            if (adressFilter.Country != null && adressFilter.Country != "")
                trainingCentersQuerable = trainingCentersQuerable
                    .Where(e => e.Adress != null
                    && e.Adress.Country != null
                    && e.Adress.Country.ToLower() == adressFilter.Country.ToLower());

            if (adressFilter.City != null && adressFilter.City != "")
                trainingCentersQuerable = trainingCentersQuerable
                    .Where(e => e.Adress != null
                    && e.Adress.City != null
                    && e.Adress.City.ToLower() == adressFilter.City.ToLower());

            if (adressFilter.Street != null && adressFilter.Street != "")
                trainingCentersQuerable = trainingCentersQuerable
                    .Where(e => e.Adress != null
                    && e.Adress.Street != null
                    && e.Adress.Street.ToLower() == adressFilter.Street.ToLower());

            if (adressFilter.House != null && adressFilter.House != "")
                trainingCentersQuerable = trainingCentersQuerable
                    .Where(e => e.Adress != null 
                    && e.Adress.House != null 
                    && e.Adress.House.ToLower() == adressFilter.House.ToLower());



            return await trainingCentersQuerable.ToListAsync();
        }
    }
}
