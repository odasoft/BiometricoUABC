namespace MovieRental.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.RentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.RentalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            var customers = new List<Customer>
            {
                new Customer{FirstName="Lalo",LastName="Tamayo",Email="dfsasdf@gmail.com"}
            };
            customers.ForEach(s => context.Customers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie{Name="Vengadores",Genre="Action",Release_Year=2015,Language="Ingles",Rental_Fee=15,Description="8/8"}
            };
            movies.ForEach(s => context.Movies.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var inventories = new List<Inventory>
            {
                new Inventory{MovieID=1,Stock=10}
            };
            foreach (Inventory e in inventories)
            {
                var inventoryInDataBase = context.Rentals.Where(
                    s =>
                         s.Movies.ID == e.MovieID).SingleOrDefault();
                if (inventoryInDataBase == null)
                {
                    context.Inventories.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
