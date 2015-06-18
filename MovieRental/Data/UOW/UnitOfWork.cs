using Data.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UOW
{
    public class UnitOfWork : IDisposable
    {
        
        private RentalContext context = new RentalContext();
                
        private GenericRepository<Movie> movieRepository;        
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Rental> rentalRepository;
        private GenericRepository<Inventory> inventoryRepository;


        public GenericRepository<Movie> MovieRepository
        {
            get
            {
                if(this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if(this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Rental> RentalRepository
        {
            get
            {
                if(this.rentalRepository == null)
                {
                    this.rentalRepository = new GenericRepository<Rental>(context);
                }
                return rentalRepository;
            }
        }

        public GenericRepository<Inventory> InventoryRepository
        {
            get
            {
                if(this.inventoryRepository == null)
                {
                    this.inventoryRepository = new GenericRepository<Inventory>(context);
                }                
                return inventoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) 
        {
            if (!this.disposed) 
            {
                if (disposing) 
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

