using BSynchro.Application.Abstraction;
using BSynchro.Application.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Application.Customer.Query
{
    public class UserInfoQuery:IRequest<UserInfoResponse>
    {
        public int customerId { get; set; }
        public UserInfoQuery(int customerId)
        {
            this.customerId = customerId;
        }
    }
    public class UserInfoHandler : IRequestHandler<UserInfoQuery, UserInfoResponse>
    {
        private readonly ICustomerHelper _customerHelper;
        public UserInfoHandler(ICustomerHelper customerHelper)
        {
            _customerHelper = customerHelper;
        }

        public async Task<UserInfoResponse> Handle(UserInfoQuery request, CancellationToken cancellationToken)
        {
            return _customerHelper.UserInfo(request.customerId);
        }
    }
}
