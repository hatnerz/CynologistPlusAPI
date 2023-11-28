using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(CynologistPlusContext context) : base(context)
        {
        }

        public async Task<CreationResult> CreateNewOrder(Order order)
        {
            if (order.DogTrainingCenterId == null)
                return CreationResult.IncorrectData;

            bool isDogExists = await _context.Dogs.AnyAsync(e => e.Id == order.DogId);
            bool isTrainingCenterExists = await _context.DogTrainingCenters.AnyAsync(e => e.Id == order.DogTrainingCenterId);
            if (!isDogExists || !isTrainingCenterExists)
                return CreationResult.IncorrectRefference;
            if (order.OrderDate == null)
                order.OrderDate = DateTime.Now;
            order.IsPaid = false;
            order.Approved = false;
            order.IsCompleted = false;
            _context.Orders.Add(order);
            return CreationResult.Success;
        }

        public async Task<DeletingResult> DeletingOrder(int orderId)
        {
            var foundOrder = _context.Orders.Find(orderId);
            if (foundOrder == null)
                return DeletingResult.ItemNotFound;
            _context.Orders.Remove(foundOrder);
            await _context.SaveChangesAsync();
            return DeletingResult.Success;
        }

        public Task<ICollection<Order>> GetClientOrders(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Order>> GetDogTrainingCenterOrder(int trainingCenterId)
        {
            throw new NotImplementedException();
        }

        public Task<ModifyResult> ModifyOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
