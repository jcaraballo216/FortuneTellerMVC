using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (customer.Age % 2 ==0)
            {
                ViewBag.RetirementAge = 75;
            }
            else
            {
                ViewBag.RetirementAge = 90;
            }

            if (customer.NumberOfSiblings == 0)
            {
                ViewBag.Places = "Puerto Rico";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                ViewBag.Places = "San Diego";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                ViewBag.Places = "Texas";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                ViewBag.Places = "Florida";
            }
            else if (customer.NumberOfSiblings == 4)
            {
                ViewBag.Places = "Detroit";
            }
            else
            {
                ViewBag.Places = "Cardboard box in Save-A-Lot";
            }

            switch (customer.FavoriteColor.ToLower())
            {
                case "red":
                    ViewBag.sweetCars = "Lambo";
                    break;
                case "orange":
                    ViewBag.sweetCars = "Hummer";
                    break;
                case "yellow":
                    ViewBag.sweetCars = "Porche";
                    break;
                case "green":
                    ViewBag.sweetCars = "BMW";
                    break;
                case "blue":
                    ViewBag.sweetCars = "Prius";
                    break;
                case "indigo":
                    ViewBag.sweetCars = "Motorcycle";
                    break;
                case "violet":
                    ViewBag.sweetCars = "Limo";
                    break;
                default:
                    ViewBag. sweetCars = "none";
                    break;
            }

            if (customer.BirthMonth == "January")
            {
                ViewBag.dollars = "$100,000";

            }
            else if (customer.BirthMonth == "Febuary")
            {
                ViewBag.dollars = "$100,000";
            }
            else if (customer.BirthMonth == "March")
            {
                ViewBag.dollars = "$100,000";
            }
            else if (customer.BirthMonth == "April")
            {
                ViewBag.dollars = "$100,000";
            }
            else if (customer.BirthMonth == "May")
            {
                ViewBag.dollars = "$300,000";
            }
            else if (customer.BirthMonth == "June")
            {
                ViewBag.dollars = "$300,000";
            }
            else if (customer.BirthMonth == "July")
            {
                ViewBag.dollars = "$300,000";
            }
            else if (customer.BirthMonth == "August")
            {
                ViewBag.dollars = "$300,000";
            }
            else if (customer.BirthMonth == "September")
            {
                ViewBag.dollars = "$500,000";
            }
            else if (customer.BirthMonth == "October")
            {
                ViewBag.dollars = "$500,000";
            }
            else if (customer.BirthMonth == "November")
            {
                ViewBag.dollars = "$500,000";
            }
            else if (customer.BirthMonth == "December")
            {
                ViewBag.dollars = "$500,000";
            }
            else
            {
                ViewBag.dollars = "$0.00";
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
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            Customer customer = db.Customers.Find(id);
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
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
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
            Customer customer = db.Customers.Find(id);
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
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
