using WebAPI.DataBase;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface ITrainingCenterService
    {
        public Task<CreationResult> AddTrainingCenter(DogTrainingCenter trainingCenter);

        public Task<DeletingResult> DeleteTrainingCenter(int trainingCenterId);

        public Task<ModifyResult> AddCynologistToTrainingCenter(int trainingCenterId, int cynologistId);

        public Task<ModifyResult> AddManagerToTrainingCenter(int trainingCenterId, int managerId);

        public Task<ModifyResult> ChangeTrainingCenterAdress(int trainingCenterId, Adress adress);

        public Task<ICollection<DogTrainingCenter>> GetTrainingCenters();

        public Task<ICollection<DogTrainingCenter>> GetTrainingCentersWithFilters(Adress adressFilter);

        public Task<ICollection<Cynologist>> GetTrainingCenterCynologists(int trainingCenterId);

        public Task<DogTrainingCenter?> GetTrainingCenter(int id);

        public Task<DogTrainingCenter?> GetManagerTrainingCenter(int managerId);
    }
}
