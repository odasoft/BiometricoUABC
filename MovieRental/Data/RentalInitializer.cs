using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Data
{
    public class RentalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RentalContext>
    {
        protected override void Seed(RentalContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{FirstName="Carson",LastName="Alexander",Email="fdsawe@gmail.com"}
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie{Name="Los Vengadores",Genre="Action",Release_Year=2015,Language="Ingles",Rental_Fee=20,Description="Muy buena"}
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();

            var inventories = new List<Inventory>
            {
                new Inventory{MovieID=1,Stock=10}
            };
            inventories.ForEach(s => context.Inventories.Add(s));
            context.SaveChanges();

            var rentals = new List<Rental>
            {
                new Rental{CustomerID=1,MovieID=1,Rental_Date=DateTime.Parse("25-05-2015"),Due_Date=DateTime.Parse("25-06-2015"),Overdue_Fee=15}
            };
            rentals.ForEach(s => context.Rentals.Add(s));
            context.SaveChanges();
        }
    }
}