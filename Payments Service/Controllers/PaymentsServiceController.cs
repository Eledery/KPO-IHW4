using Microsoft.AspNetCore.Mvc;

namespace Payments_Service.Controllers
{
    [Route("accounts/[controller]")]
    [ApiController]
    public class PaymentsServiceController : ControllerBase
    {
        private PaymentsDbContext _dbContext;
        private Commons.Factories.AccountFactory _factory = new Commons.Factories.AccountFactory();
        public PaymentsServiceController(PaymentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromQuery] Guid userId)
        {
            if (_dbContext.Accounts.Any(item => item.AccountId == userId))
            {
                return BadRequest();
            }
            {
                var account = _factory.Create(userId);
                try
                {
                    await _dbContext.Accounts.AddAsync(account);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok(account);
            }
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromQuery] Guid userId, [FromQuery] int amount)
        {
            if (amount < 0)
            {
                return BadRequest($"amount: {amount}<0");
            }
            var account = await _dbContext.Accounts.FindAsync(userId);
            if (account == null)
            {
                return BadRequest();
            }
            account.Balance += amount;
            await _dbContext.SaveChangesAsync();
            return Ok(account);
        }
        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance([FromQuery] Guid userId)
        {
            var account = await _dbContext.Accounts.FindAsync(userId);
            if (account == null)
            {
                return BadRequest();
            }
            return Ok(account);
        }


        // Здесь должен быть контроллер для Inbox/Outbox паттерна, обеспечивающий снятие денег с баланса
    }
}
