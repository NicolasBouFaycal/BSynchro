using BSynchro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Persistence
{
    public class ApplicationDbContext : DbContext
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
