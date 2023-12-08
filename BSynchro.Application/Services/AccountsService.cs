using BSynchro.Application.Abstraction;
using BSynchro.Domain.Models;
using BSynchro.Persistence;

namespace BSynchro.Application.Services
{
    public class AccountsService : IAccountsHelper
    {
        private readonly ApplicationDbContext _context;
        public AccountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AccountCreation(int customerId)
        {
            Account account = new Account();
            account.UserID = customerId;
            _context.Add(account);  
            _context.SaveChanges();
            return account.AccountID;

        }
    }
}
