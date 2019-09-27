using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using luce_MIS4200_1045.DAL;
using luce_MIS4200_1045.Models;

namespace luce_MIS4200_1045.Controllers
{
    public class customerOrdersController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: customerOrders
        public ActionResult Index()
        {
            
            var orders = db.Orders.Include(c => c.customer);
            return View(orders.ToList());
        }

        // GET: customerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerOrder customerOrder = db.Orders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: customerOrders/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "fullName");
            return View();
        }

        // POST: customerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerOrderID,customerID,orderDate")] customerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(customerOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.Customers, "customerID", "fullName", customerOrder.customerID);
            return View(customerOrder);
        }

        // GET: customerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerOrder customerOrder = db.Orders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "firstName", customerOrder.customerID);
            return View(customerOrder);
        }

        // POST: customerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerOrderID,customerID,orderDate")] customerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "firstName", customerOrder.customerID);
            return View(customerOrder);
        }

        // GET: customerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerOrder customerOrder = db.Orders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: customerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerOrder customerOrder = db.Orders.Find(id);
            db.Orders.Remove(customerOrder);
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
