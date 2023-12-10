using BSynchro.Application.Abstraction;
using BSynchro.Application.Account.Command;
using BSynchro.Application.Customer.Query;
using BSynchro.Application.CustomModels;
using BSynchro.Persistence;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountsController : ControllerBase
    {
        private readonly ICustomerHelper _customerHelper;
        private readonly IMediator _mediator;

        private readonly ApplicationDbContext _context;
        public AccountsController(IMediator mediator,ApplicationDbContext context, ICustomerHelper customerHelper)
        {
            _customerHelper= customerHelper;
            _context = context;
            _mediator= mediator;
        }


        [HttpPost("OpenAccount")]
        public async  Task<IActionResult> OpenAccount([FromBody]OpenAccount openAccount)
        {
            var result = await _mediator.Send(new OpenAccountCommand(openAccount.customerID,openAccount.initialCredit));
            return Ok(new { message = result });
        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> UserInfo([FromQuery] int customerId)
        {
            var result = await _mediator.Send(new UserInfoQuery(customerId));

            if (result == null)
            {
                return Ok(new { message = "Error Check customer Id " });

            }
            else
            {
                return Ok( result );

            }            
        }
    }
}
