using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.DI
{
    public interface IOrderService
    {
        public Task<CreationResult> CreateNewOrder(CreateOrderModel order);

        public Task<DeletingResult> DeletingOrder(int orderId);

        public Task<ModifyResult> ModifyOrder(Order order);

        public Task<ICollection<Order>> GetClientOrders(int clientId);

        public Task<ICollection<Order>> GetDogTrainingCenterOrder(int trainingCenterId);

    }
}
