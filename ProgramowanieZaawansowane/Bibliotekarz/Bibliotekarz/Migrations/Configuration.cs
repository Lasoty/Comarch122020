namespace Bibliotekarz.Migrations
{
    using Bibliotekarz.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bibliotekarz.Model.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bibliotekarz.Model.AppDbContext context)
        {
            if (!context.Books.Any())
            {
                Book book = new Book
                {
                    Author = "Leszek Lewandowski",
                    Title = "Programowanie w C#",
                    PageCount = 456,
                    IsBorrowed = false
                };

                context.Books.Add(book);


                var saveItensCount = context.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
