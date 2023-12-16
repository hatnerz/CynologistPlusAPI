using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class ManagerService : ServiceBase, IManagerService
    {
        public ManagerService(CynologistPlusContext context) : base(context)
        { }

        public async Task<DeletingResult> DeleteManager(int managerId)
        {
            var foundManager = _context.Managers.Find(managerId);
            if (foundManager == null)
                return DeletingResult.ItemNotFound;
            var foundCredentials = _context.AuthCredentials.Find(foundManager.AuthCredentialId);
            if (foundCredentials == null)
                return DeletingResult.ItemNotFound;
            _context.Managers.Remove(foundManager);
            _context.AuthCredentials.Remove(foundCredentials);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public async Task<ICollection<Manager>> GetManagers()
        {
            var foundManagers = await _context.Managers.Include(e => e.DogTrainingCenter).Include(e => e.AuthCredential).ToListAsync();
            return foundManagers;
        }

        public async Task<ModifyResult> ModifyManager(Manager manager)
        {
            var foundManager = await _context.Managers.FindAsync(manager.Id);
            if (foundManager == null)
                return ModifyResult.IncorrectData;
            if(manager.DogTrainingCenterId != null)
            {
                var foundDogTrainingCenter = await _context.DogTrainingCenters.FindAsync(manager.DogTrainingCenterId);
                if (foundDogTrainingCenter == null)
                    return ModifyResult.IncorrectRefference;
            }
            foundManager.DogTrainingCenterId = manager.DogTrainingCenterId;
            foundManager.FirstName = manager.FirstName;
            foundManager.LastName = manager.LastName;
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }
    }
}