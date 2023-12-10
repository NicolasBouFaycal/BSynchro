using BSynchro.Application.Abstraction;
using BSynchro.Application.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Application.Account.Command
{
    public class OpenAccountCommand :IRequest<string>
    {
        public int _customerId { get; set; }
        public decimal _initialCredit { get; set; }
        public OpenAccountCommand(int customerId, decimal initialCredit)
        {
            _customerId=customerId;
            _initialCredit=initialCredit;
        }
    }
    public class OpenAccountHandler : IRequestHandler<OpenAccountCommand, string>
    {
        private readonly ICustomerHelper _customerHelper;
        public OpenAccountHandler(ICustomerHelper customerHelper)
        {
            _customerHelper = customerHelper;
        }

        public async Task<string> Handle(OpenAccountCommand request, CancellationToken cancellationToken)
        {
            return _customerHelper.OpenAccount(request._customerId, request._initialCredit);
        }
    }
}
