using BSynchro.Application.Abstraction;
using BSynchro.Application.CustomModels;
using Microsoft.AspNetCore.Mvc;

namespace BSynchro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsHelper _accountsHelper;
        private readonly ITransactionsHelper _transactionsHelper;

        public AccountsController(IAccountsHelper accountsHelper, ITransactionsHelper transactionsHelper)
        {
            _accountsHelper = accountsHelper;
            _transactionsHelper = transactionsHelper;
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
    }
}
