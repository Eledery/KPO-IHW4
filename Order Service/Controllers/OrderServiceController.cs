using Microsoft.AspNetCore.Mvc;

namespace Order_Service.Controllers
{
    [Route("orders/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly OrderDbContext _dbContext;
        private Commons.Factories.OrderFactory _factory = new Commons.Factories.OrderFactory();
        public OrderServiceController(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromQuery] Guid userId, int amount, string desc)
        {
            var order = _factory.Create(userId, amount, desc);
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return Ok(order);
        }
        [HttpGet("get-orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            if (!_dbContext.Orders.Any())
            {
                return BadRequest();
            }
            var result = _dbContext.Orders.ToList();
            return Ok(result);
        }
        [HttpGet("order-status")]
        public async Task<IActionResult> GetOrderStatus([FromQuery] Guid orderId)
        {
            var result = await _dbContext.Orders.FindAsync(orderId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result.Status);
        }
    }
}
