using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;
using WebAPI.Services;

namespace WebAPI.Services
{
    public class ClientService : ServiceBase, IClientService
    {
        public ClientService(CynologistPlusContext context) : base(context)
        { }

        public async Task<ModifyResult> ChangeClientData(Client client)
        {
            var foundClient = _context.Clients.Find(client.Id);
            if (foundClient == null)
                return ModifyResult.IncorrectData;
            foundClient.FirstName = client.FirstName;
            foundClient.LastName = client.LastName;
            foundClient.Email = client.Email;
            foundClient.Phone = client.Phone;
            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }

        public async Task<DeletingResult> DeleteClient(int id)
        {
            var foundClient = _context.Clients.Find(id);
            if (foundClient == null)
                return DeletingResult.ItemNotFound;
            var foundCredentials = _context.AuthCredentials.Find(foundClient.AuthCredentialId);
            if (foundCredentials == null)
                return DeletingResult.ItemNotFound;
            _context.Clients.Remove(foundClient);
            _context.AuthCredentials.Remove(foundCredentials);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public async Task<Client?> GetClient(int id)
        {
            var foundClient = await _context.Clients.FindAsync(id);
            return foundClient;
        }
    }
}