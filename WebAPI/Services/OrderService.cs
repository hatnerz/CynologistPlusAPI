using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(CynologistPlusContext context) : base(context)
        {
        }

        public async Task<CreationResult> CreateNewOrder(CreateOrderModel orderData)
        {
            Order newOrder = new Order();
            newOrder.Comment = orderData.Comment;
            newOrder.DogId = orderData.DogId;
            newOrder.DogTrainingCenterId = orderData.DogTrainingCenterId;
            bool isDogExists = await _context.Dogs.AnyAsync(e => e.Id == orderData.DogId);
            bool isTrainingCenterExists = await _context.DogTrainingCenters.AnyAsync(e => e.Id == orderData.DogTrainingCenterId);
            if (!isDogExists || !isTrainingCenterExists)
                return CreationResult.IncorrectRefference;
            DateTime correctDate = DateTime.UtcNow;
            newOrder.OrderDate = correctDate;
            newOrder.OrderDateTimeOffset = orderData.TimeOffset;
            newOrder.IsPaid = false;
            newOrder.Approved = false;
            newOrder.IsCompleted = false;
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
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

        public async Task<ICollection<Order>> GetClientOrders(int clientId)
        {
            var userOrders = await _context.Clients
                .Where(u => u.Id == clientId)
                .SelectMany(u => u.Dogs)
                .SelectMany(d => d.Orders)
                .ToListAsync();

            return userOrders;
        }

        public async Task<ICollection<Order>> GetDogTrainingCenterOrder(int trainingCenterId)
        {
            var orders = await _context.Orders.Where(e => e.DogTrainingCenterId == trainingCenterId).ToListAsync();
            return orders;
        }

        public async Task<ModifyResult> ModifyOrder(Order order)
        {
            var foundOrder = await _context.Orders.FindAsync(order.Id);
            if (foundOrder == null)
                return ModifyResult.IncorrectData;

            foundOrder.OrderDate = order.OrderDate ?? foundOrder.OrderDate;
            foundOrder.OrderDateTimeOffset = order.OrderDateTimeOffset ?? foundOrder.OrderDateTimeOffset;
            foundOrder.Price = order.Price ?? foundOrder.Price;
            foundOrder.Currency = order.Currency ?? foundOrder.Currency;
            foundOrder.IsPaid = order.IsPaid ?? foundOrder.IsPaid;
            foundOrder.Approved = order.Approved ?? foundOrder.Approved;
            foundOrder.IsCompleted = order.IsCompleted ?? foundOrder.IsCompleted;
            foundOrder.Comment = order.Comment ?? foundOrder.Comment;
            foundOrder.DogTrainingCenterId = order.DogTrainingCenterId ?? foundOrder.DogTrainingCenterId;
            foundOrder.DogId = order.DogId ?? foundOrder.DogId;

            await _context.SaveChangesAsync();
            return ModifyResult.Success;
        }
    }
}
