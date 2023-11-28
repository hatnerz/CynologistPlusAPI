using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IClientService
    {
        public Task<Client?> GetClient(int id);

        public Task<DeletingResult> DeleteClient(int id);

        public Task<ModifyResult> ChangeClientData(Client client);

    }
}
