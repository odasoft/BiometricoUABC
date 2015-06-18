using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Data;

namespace Business
{
    public class QueryRental
    {
        public static Boolean CheckMovieStock(int id, int quantity) 
        {
            var db = new RentalContext();
            var inventory = db.Inventories.Where(inv=>inv.MovieID == id);
            var movieInventory = inventory.FirstOrDefault<Inventory>();
            if (movieInventory.Stock >= 0 && movieInventory.Stock >= quantity)
                return true;
            return false;
        }

        public static void UpdateMovieStock(int id, int quantity)
        {
            var db = new RentalContext();
            var inventory = db.Inventories.Where(inv => inv.MovieID == id);
            var movieInventory = inventory.FirstOrDefault<Inventory>();
            movieInventory.Stock -= quantity;
            db.SaveChanges();
        }

        public static void UpdateRentalMovieStock(int id) 
        {
            var db = new RentalContext();
            var rentals = db.Rentals.Where(r=>r.ID == id);
            for (int i = 0; i < rentals.Count(); i++ )
            {
                UpdateMovieStock(rentals.ElementAt(i).MovieID,1);
            }
            db.SaveChanges();
        }
        public static void AddMovieStock(int id)
        {
            var db = new RentalContext();
            var inventory = db.Inventories.Where(inv => inv.MovieID == id);
            var movieInventory = inventory.FirstOrDefault<Inventory>();
            movieInventory.Stock++; ;
            db.SaveChanges();
        }

    }
}