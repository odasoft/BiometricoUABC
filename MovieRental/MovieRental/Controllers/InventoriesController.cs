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
    public class InventoriesController : Controller
    {
        /*
        GenericRepository<Inventory> repository = new GenericRepository<Inventory>(new RentalContext());
        GenericRepository<Movie> repositoryMovies = new GenericRepository<Movie>(new RentalContext());
         */
        private UnitOfWork unitOfWork = new UnitOfWork();
        //RentalContext db = new RentalContext();
        // GET: Inventories
        /*
        public ActionResult Index()
        {
            //var inventories = db.Inventories.Include(i => i.Movies);

            repository.Include();
            return View(repository.Get());
        }
        */
        public ViewResult Index() 
        {
            var inventories = unitOfWork.InventoryRepository.Get();
            return View(inventories.ToList());
        }
        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inventory inventory = repository.GetByID(id);
            Inventory inventory = unitOfWork.InventoryRepository.GetByID(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            //ViewBag.MovieID = new SelectList(repositoryMovies.Get(), "ID", "Name");
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MovieID,Stock")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                //repository.Insert(inventory);
                unitOfWork.InventoryRepository.Insert(inventory);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.MovieID = new SelectList(repositoryMovies.Get(), "ID", "Name", inventory.MovieID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", inventory.MovieID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inventory inventory = repository.GetByID(id);
            Inventory inventory = unitOfWork.InventoryRepository.GetByID(id);            
            if (inventory == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MovieID = new SelectList(repositoryMovies.Get(), "ID", "Name", inventory.MovieID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", inventory.MovieID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MovieID,Stock")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                //repository.Update(inventory);
                unitOfWork.InventoryRepository.Update(inventory);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.MovieID = new SelectList(repositoryMovies.Get(), "ID", "Name", inventory.MovieID);
            ViewBag.MovieID = new SelectList(unitOfWork.MovieRepository.Get(), "ID", "Name", inventory.MovieID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inventory inventory = repository.GetByID(id);
            Inventory inventory = unitOfWork.InventoryRepository.GetByID(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Inventory inventory = repository.GetByID(id);
            //repository.Delete(inventory);
            Inventory inventory = unitOfWork.InventoryRepository.GetByID(id);
            unitOfWork.InventoryRepository.Delete(inventory);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repository.Dispose();
                unitOfWork.InventoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
