using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IManagerService
    {
        public Task<ICollection<Manager>> GetManagers();

        public Task<ModifyResult> ModifyManager(Manager manager);

        public Task<DeletingResult> DeleteManager(int managerId);
    }
}