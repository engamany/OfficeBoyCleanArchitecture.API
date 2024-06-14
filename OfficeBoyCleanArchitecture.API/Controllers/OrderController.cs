using Microsoft.AspNetCore.Mvc;
using OfficeBoy.Models;

namespace OfficeBoyCleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            await _orderService.PlaceOrder(order);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrder(order);
            return Ok();
        }

        
    }
}
