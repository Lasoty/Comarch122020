using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Model
{
    //Dlaczego nie działa?!

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DbContextConnectionString")
        {
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Borrowers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasKey(e => e.Id);

            modelBuilder.Entity<Book>().HasOptional(e => e.Borrower);
        }
    }
}
