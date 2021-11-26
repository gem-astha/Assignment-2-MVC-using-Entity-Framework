using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAss.Models;

namespace MVCAss.Controllers
{
    [Authorize]
    public class Employee1Controller : Controller
    {
        private OfficeEntities db = new OfficeEntities();

        // GET: Employee1
        public ActionResult Index()
        {
            return View(db.Employee1.ToList());
        }

        // GET: Employee1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // GET: Employee1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Dob,Gender,Email_Address")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Employee1.Add(employee1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee1);
        }

        // GET: Employee1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Dob,Gender,Email_Address")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee1);
        }

        // GET: Employee1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee1 employee1 = db.Employee1.Find(id);
            db.Employee1.Remove(employee1);
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
