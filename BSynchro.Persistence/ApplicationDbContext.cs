using BSynchro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace chedid.DataBase
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

    }
}
