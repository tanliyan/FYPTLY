using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYPTLY.Models;

namespace FYPTLY.Controllers
{
    public class MedicalTestController : Controller
    {
        private FYPTLYEntities db = new FYPTLYEntities();

        // GET: MedicalTest
        public ActionResult Index()
        {
            var medical_Test = db.Medical_Test.Include(m => m.Appointment).Include(m => m.Staff);
            return View(medical_Test.ToList());
        }

        // GET: MedicalTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Test medical_Test = db.Medical_Test.Find(id);
            if (medical_Test == null)
            {
                return HttpNotFound();
            }
            return View(medical_Test);
        }

        // GET: MedicalTest/Create
        public ActionResult Create()
        {
            ViewBag.appointment_id = new SelectList(db.Appointments, "appointment_id", "appointment_type");
            ViewBag.Staff_id = new SelectList(db.Staffs, "staff_id", "staff_name");
            return View();
        }

        // POST: MedicalTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medical_Test_id,test_name,test_description,Staff_id,appointment_id")] Medical_Test medical_Test)
        {
            if (ModelState.IsValid)
            {
                db.Medical_Test.Add(medical_Test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.appointment_id = new SelectList(db.Appointments, "appointment_id", "appointment_type", medical_Test.appointment_id);
            ViewBag.Staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", medical_Test.Staff_id);
            return View(medical_Test);
        }

        // GET: MedicalTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Test medical_Test = db.Medical_Test.Find(id);
            if (medical_Test == null)
            {
                return HttpNotFound();
            }
            ViewBag.appointment_id = new SelectList(db.Appointments, "appointment_id", "appointment_type", medical_Test.appointment_id);
            ViewBag.Staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", medical_Test.Staff_id);
            return View(medical_Test);
        }

        // POST: MedicalTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medical_Test_id,test_name,test_description,Staff_id,appointment_id")] Medical_Test medical_Test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_Test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.appointment_id = new SelectList(db.Appointments, "appointment_id", "appointment_type", medical_Test.appointment_id);
            ViewBag.Staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", medical_Test.Staff_id);
            return View(medical_Test);
        }

        // GET: MedicalTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Test medical_Test = db.Medical_Test.Find(id);
            if (medical_Test == null)
            {
                return HttpNotFound();
            }
            return View(medical_Test);
        }

        // POST: MedicalTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medical_Test medical_Test = db.Medical_Test.Find(id);
            db.Medical_Test.Remove(medical_Test);
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
