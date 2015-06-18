using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Data;
using Business;
using Data.Repository;
using Data.UOW;

namespace MovieRental.Controllers
{
    public class RentalsController : Controller
    {
        /*
        GenericRepository<Rental> repository = new GenericRepository<Rental>(new RentalContext());
        GenericRepository<Customer> repositoryCustomer = new GenericRepository<Customer>(new RentalContext());
        GenericRepository<Movie> repositoryMovie = new GenericRepository<Movie>(new RentalContext());
        */
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Rentals
        /*
        public ActionResult Index()
        {
            return View(repository.Get());
        }
        */
        public ViewResult Index() 
        {
            var rentals = unitOfWork.RentalRepository.Get();
            return View(rentals.ToList());
        }
        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rental rental = repository.GetByID(id);
            Rental rental = unitOfWork.RentalRepository.GetByID(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            //ViewBag.CustomerID = new SelectList(repositoryCustomer.Get(), "ID", "FirstName");
            //ViewBag.MovieID = new SelectList(repositoryMovie.Get(), "ID", "Name");
            ViewBag.CustomerID = new SelectList(unitOfWork.CustomerRepository.Get(), "ID", "FirstName");
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,MovieID,Rental_Date,Due_Date,Overdue_Fee")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                if (QueryRental.CheckMovieStock(rental.MovieID, 1)){
                    //repository.Insert(rental);
                    unitOfWork.RentalRepository.Insert(rental);
                    unitOfWork.Save();
                    QueryRental.UpdateMovieStock(rental.MovieID, 1);
                }
                else
                    System.Diagnostics.Debug.Write("Ya no hay");
                return RedirectToAction("Index");
            }

            //ViewBag.CustomerID = new SelectList(repositoryCustomer.Get(), "ID", "FirstName", rental.CustomerID);
            //ViewBag.MovieID = new SelectList(repositoryMovie.Get(), "ID", "Name", rental.MovieID);
            ViewBag.CustomerID = new SelectList(unitOfWork.CustomerRepository.Get(), "ID", "FirstName", rental.CustomerID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", rental.MovieID);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rental rental = repository.GetByID(id);
            Rental rental = unitOfWork.RentalRepository.GetByID(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CustomerID = new SelectList(repositoryCustomer.Get(), "ID", "FirstName", rental.CustomerID);
            //ViewBag.MovieID = new SelectList(repositoryMovie.Get(), "ID", "Name", rental.MovieID);
            ViewBag.CustomerID = new SelectList(unitOfWork.CustomerRepository.Get(), "ID", "FirstName", rental.CustomerID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", rental.MovieID);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,MovieID,Rental_Date,Due_Date,Overdue_Fee")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                //repository.Update(rental);
                unitOfWork.RentalRepository.Update(rental);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.CustomerID = new SelectList(repositoryCustomer.Get(), "ID", "FirstName", rental.CustomerID);
            //ViewBag.MovieID = new SelectList(repositoryMovie.Get(), "ID", "Name", rental.MovieID);
            ViewBag.CustomerID = new SelectList(unitOfWork.CustomerRepository.Get(), "ID", "FirstName", rental.CustomerID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", rental.MovieID);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rental rental = repository.GetByID(id);
            Rental rental = unitOfWork.RentalRepository.GetByID(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Rental rental = repository.GetByID(id);
            //repository.Delete(rental);
            Rental rental = unitOfWork.RentalRepository.GetByID(id);
            unitOfWork.RentalRepository.Delete(rental);
            unitOfWork.Save();
            QueryRental.AddMovieStock(rental.MovieID);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repository.Dispose();
                unitOfWork.RentalRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
