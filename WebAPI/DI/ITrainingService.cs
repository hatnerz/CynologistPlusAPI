using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface ITrainingService
    {
        public Task<Training> CreateTraining(Training training);

        public Task<DeletingResult> DeleteTraining(int trainingId);

        public Task<Training> PlanTrainings(ICollection<Training> training);

        public Task<ModifyResult> ChangeTrainingData(Training training);
    }
}
