using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYPTLY.Models;
using System.Net.Mail;


namespace FYPTLY.Controllers
{
    public class PatientController : Controller
    {
        private FYPTLYEntities db = new FYPTLYEntities();

        // GET: Patient
        //Searching
        public ActionResult Index(string searchString)
        {
            var patients = from p in db.Patients
                           select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                // patients = patients.Where(p => p.Nric == searchString);
                //patients = patients = patients.Where(p => p.Nric.Contains(searchString));
                patients = patients = patients.Where(p => p.Nric.Contains(searchString) || p.p_gender == searchString);
            }
            return View(patients);
        }

        //Sorting
        public ActionResult Index3(string sortOrder)
        {

            ViewBag.NricSortParm = String.IsNullOrEmpty(sortOrder) ? "Nric_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "p_name_desc" : "Name";
            ViewBag.GenderSortParm = String.IsNullOrEmpty(sortOrder) ? "p_gender_desc" : "Gender";



            var patients = from p in db.Patients
                           select p;
            switch (sortOrder)
            {

                case "Nric_desc":
                    patients = patients.OrderByDescending(p => p.Nric);
                    break;

                case "Name":
                    patients = patients.OrderBy(p => p.p_name);
                    break;

                case "Name_desc":
                    patients = patients.OrderByDescending(p => p.p_name);
                    break;

                case "Gender":
                    patients = patients.OrderBy(p => p.p_gender);
                    break;

                case "Gender_desc":
                    patients = patients.OrderByDescending(p => p.p_gender);
                    break;

            }
            return View(patients);
        }

       



        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nric,p_name,p_address,p_gender,p_dob,p_email,postal_code")] Patient patient)
        {

            //can create the auto value here or request for NRIC/ID from the view before submission
            patient.Patient_id = (int)DateTime.Now.TimeOfDay.Milliseconds;

            //if (ModelState.IsValid)
            //{

            db.Patients.Add(patient);
            db.SaveChanges();

            // Send Email
            SendEmail(patient);

            return RedirectToAction("Index");
            //}

            //return View(patient);
        }

        private void SendEmail(Patient patient)
        {

            MailMessage mm = new MailMessage("liyantanxtly@gmail.com", patient.p_email);
            mm.Subject = "Account Registered Successfully!";
            mm.Body = "Please be informed your registration with Parkway Pantai is successful. Your login id and password will be sent to you within 5 working days. Should you not receive them, please call our customer service at 1800-9999999.  Thank you for your support. This email is computer generated, no signature is required.";

            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("liyantanxtly@gmail.com", "gmailpassword123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nric,p_name,p_address,p_gender,p_dob,p_email,postal_code")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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

