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
    public class CustomersController : Controller
    {
        //GenericRepository<Customer> repository = new GenericRepository<Customer>(new RentalContext());
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        // GET: Customers        
        /*
        public ActionResult Index()
        {
            return View(repository.Get());
        }*/
        public ViewResult Index() 
        {
            var customers = unitOfWork.CustomerRepository.Get();
            return View(customers.ToList());
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = repository.GetByID(id);
            Customer customer = unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //repository.Insert(customer);
                    unitOfWork.CustomerRepository.Insert(customer);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = repository.GetByID(id);
            Customer customer = unitOfWork.CustomerRepository.GetByID(id);
            unitOfWork.Save();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //repository.Update(customer);
                unitOfWork.CustomerRepository.Update(customer);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = repository.GetByID(id);
            Customer customer = unitOfWork.CustomerRepository.GetByID(id);
            unitOfWork.Save();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = repository.GetByID(id);
            //repository.Delete(customer);
            Customer customer = unitOfWork.CustomerRepository.GetByID(id);
            unitOfWork.CustomerRepository.Delete(customer);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repository.Dispose();
                unitOfWork.CustomerRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
