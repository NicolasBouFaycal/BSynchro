using BSynchro.Application.Abstraction;
using BSynchro.Application.CustomModels;
using BSynchro.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Application.Services
{
    public class CustomerService : ICustomerHelper
    {
        private readonly IAccountsHelper _accountsHelper;
        private readonly ITransactionsHelper _transactionsHelper;
        private readonly ApplicationDbContext _context;

        public CustomerService(IAccountsHelper accountsHelper, ITransactionsHelper transactionsHelper, ApplicationDbContext context)
        {
            _accountsHelper = accountsHelper;   
            _transactionsHelper= transactionsHelper;
            _context = context;
        }
        public string OpenAccount(int customerID, decimal initialCredit)
        {
            bool exists =   _context.Customer.Any(x => x.UserID == customerID);
            if (exists)
            {
                var accountId = _accountsHelper.AccountCreation(customerID);
                if (initialCredit > 0)
                {
                    _transactionsHelper.TransactionMade(accountId, initialCredit);
                }
                return "Inserted Successfully";
            }
            else
            {
                return "Can not Create Account Check customer Id";

            }
        }

        public  UserInfoResponse UserInfo(int customerId)
        {
            bool exists =  _context.Customer.Any(x => x.UserID == customerId);
            if (exists)
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
                        .SelectMany(a => a.Transactions.Select(t => new { t.AccountID, t.Amount, t.Timestamp }))
                })
                .FirstOrDefault();

                if (userInformation==null)
                {
                    return null;
                }
                var userInfoResponse = new UserInfoResponse
                {
                    Name = userInformation.Name,
                    Surname = userInformation.Surname,
                    Balance = userInformation.Balance ?? 0, // Handle nullable decimal
                    Transactions = userInformation.Transactions.Select(t => new TransactionInfo
                    {
                        AccountID = t.AccountID,
                        Amount = t.Amount,
                        Timestamp = t.Timestamp
                    })
                };
                

                return userInfoResponse;
            }
            else
            {
                return null;
            }
        }

    }
}
