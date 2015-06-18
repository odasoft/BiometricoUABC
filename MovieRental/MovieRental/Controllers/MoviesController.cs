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
using Data.Repository;
using Data.UOW;

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        //GenericRepository<Movie> repository = new GenericRepository<Movie>(new RentalContext());
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Movies
        /*
        public ActionResult Index()
        {
            return View(repository.Get());
        }
        */
        public ViewResult Index()
        {
            var movies = unitOfWork.MovieRepository.Get();
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = repository.GetByID(id);
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Genre,Release_Year,Language,Rental_Fee,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //repository.Insert(movie);
                unitOfWork.MovieRepository.Insert(movie);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = repository.GetByID(id);
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Genre,Release_Year,Language,Rental_Fee,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //repository.Update(movie);
                unitOfWork.MovieRepository.Update(movie);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = repository.GetByID(id);
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Movie movie = repository.GetByID(id);
            //repository.Delete(movie);
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            unitOfWork.MovieRepository.Delete(movie);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repository.Dispose();
                unitOfWork.MovieRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

