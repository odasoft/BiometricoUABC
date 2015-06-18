using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Configuration;


namespace Data
{
    public class RentalContext : DbContext
    {
        public RentalContext() : base("RentalContext")
        {
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new InventoryConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());
        }
    }
}