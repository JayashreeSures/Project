using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Cake_palace.models;
using Cake_palace.Services;

namespace Cake_palace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            await _service.PlaceOrder(order);
            return StatusCode(StatusCodes.Status201Created, "Order Created Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _service.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                return Ok(await _service.GetOrder(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(int id, [FromBody] Order order)
        {
            try
            {
                await _service.EditOrder(id, order);
                return StatusCode(StatusCodes.Status201Created, "Order Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _service.DeleteOrder(id);
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("totalordercount")]
        public async Task<IActionResult> GetOrderCount()
        {
            return Ok(await _service.GetOrderCount());
        }
    }
}
