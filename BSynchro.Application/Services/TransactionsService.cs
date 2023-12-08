using BSynchro.Application.Abstraction;
using BSynchro.Domain.Models;
using BSynchro.Persistence;


namespace BSynchro.Application.Services
{
    public class TransactionsService : ITransactionHelper
    {
        private readonly ApplicationDbContext _context;
        public TransactionsService(ApplicationDbContext context)
        {
            _context=context;
        }
        public void TransactionMade(int accountId, int initialCredit)
        {

            Transaction transaction = new Transaction();
            transaction.AccountID = accountId;
            transaction.Amount = initialCredit; 
            transaction.Timestamp = DateTime.UtcNow;
            _context.Add(transaction);
            _context.SaveChanges();

            var account = _context.Account.FirstOrDefault(a => a.AccountID == accountId);
            if (account != null)
            {
                decimal newBalance = initialCredit; 
                account.Balance = newBalance;
                _context.SaveChanges();
            }
        }
    }
}
