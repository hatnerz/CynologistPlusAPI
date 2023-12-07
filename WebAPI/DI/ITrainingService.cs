using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface ITrainingService
    {
        public Task<CreationResult> CreateTraining(Training training);

        public Task<DeletingResult> DeleteTraining(int trainingId);

        public Task<ModifyResult> ChangeTrainingData(Training training);

        public Task<ICollection<Training>> GetDogTrainings(int dogId);

        public Task<ICollection<Training>> GetCynologistTrainings(int cynologistId);

        public Task<bool> PlanTrainings(ICollection<Training> training);
    }
}
