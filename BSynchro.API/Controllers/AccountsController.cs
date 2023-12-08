using BSynchro.Application.Abstraction;
using BSynchro.Application.CustomModels;
using BSynchro.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsHelper _accountsHelper;
        private readonly ITransactionsHelper _transactionsHelper;
        private readonly ApplicationDbContext _context;
        public AccountsController(ApplicationDbContext context,IAccountsHelper accountsHelper, ITransactionsHelper transactionsHelper)
        {
            _accountsHelper = accountsHelper;
            _transactionsHelper = transactionsHelper;
            _context = context; 
        }


        [HttpPost("OpenAccount")]
        public  IActionResult OpenAccount([FromBody]OpenAccount openAccount)
        {
             var accountId=_accountsHelper.AccountCreation(openAccount.customerID);

            if (openAccount.initialCredit > 0)
            {
                _transactionsHelper.TransactionMade(accountId, openAccount.initialCredit);
            }

            return Ok();
        }

        [HttpGet("UserInfo")]
        public IActionResult UserInfo([FromQuery]int customerId)
        {
            var userInformation = _context.Customer
                .Where(c => c.UserID == customerId)
                .Include(c => c.Accounts)
                    .ThenInclude(a => a.Transactions)
                .Select(c => new
                {
                    c.Name,
                    c.Surname,
                    Balance = c.Accounts.Sum(a => a.Balance),
                    Transactions = c.Accounts
                        .SelectMany(a => a.Transactions.Select(t => new {t.AccountID, t.Amount, t.Timestamp }))
                })
                .FirstOrDefault();
            if (userInformation == null)
            {
                return NotFound(); 
            }

            return Ok(userInformation);
        }
    }
}
