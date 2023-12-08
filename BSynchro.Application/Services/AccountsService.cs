using BSynchro.Application.Abstraction;
using BSynchro.Domain.Models;
using BSynchro.Persistence;

namespace BSynchro.Application.Services
{
    public class AccountsService : IAccountHelper
    {
        private readonly ApplicationDbContext _context;
        public AccountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AccountCreation(int customerId)
        {
            Account account = new Account();
            account.AccountID = customerId;
            _context.Add(account);  
            _context.SaveChanges();
        }
    }
}
