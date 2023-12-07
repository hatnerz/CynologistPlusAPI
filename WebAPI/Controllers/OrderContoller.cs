using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel order)
        {
            CreationResult result = await _orderService.CreateNewOrder(order);
            if (result == CreationResult.Success)
                return Ok();
            if (result == CreationResult.IncorrectRefference)
                return BadRequest(new { message = "Incorrect dog or training center id" });
            else
                return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> ModifyOrder([FromBody] Order order)
        {
            ModifyResult result = await _orderService.ModifyOrder(order);
            if (result == ModifyResult.Success)
                return Ok();
            if (result == ModifyResult.IncorrectData)
                return BadRequest(new { message = "Incorrect order id" });
            return BadRequest();
        }

        [HttpGet("client/{id}")]
        public async Task<ICollection<Order>> GetClientOrders(int clientId)
        {
            return await _orderService.GetClientOrders(clientId);
        }

        [HttpGet("training-center/{id}")]
        public async Task<ICollection<Order>> GetTrainingCenterOrder(int trainingCenterId)
        {
            return await _orderService.GetDogTrainingCenterOrder(trainingCenterId);
        }
    }
}
