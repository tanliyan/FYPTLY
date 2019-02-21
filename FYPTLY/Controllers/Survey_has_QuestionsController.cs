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
    public class Survey_has_QuestionsController : Controller
    {
        private FYPTLYEntities db = new FYPTLYEntities();

        // GET: Survey_has_Questions
        public ActionResult Index()
        {
            var survey_has_Questions = db.Survey_has_Questions.Include(s => s.Question).Include(s => s.Survey);
            return View(survey_has_Questions.ToList());
        }

        // GET: Survey_has_Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey_has_Questions survey_has_Questions = db.Survey_has_Questions.Find(id);
            if (survey_has_Questions == null)
            {
                return HttpNotFound();
            }
            return View(survey_has_Questions);
        }

        // GET: Survey_has_Questions/Create
        public ActionResult Create()
        {
            ViewBag.questions_id = new SelectList(db.Questions, "questions_id", "question_text");
            ViewBag.Survey_id = new SelectList(db.Surveys, "survey_id", "survey_name");
            return View();
        }

        // POST: Survey_has_Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questions_id,Survey_id,answer")] Survey_has_Questions survey_has_Questions)
        {
            if (ModelState.IsValid)
            {
                db.Survey_has_Questions.Add(survey_has_Questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.questions_id = new SelectList(db.Questions, "questions_id", "question_text", survey_has_Questions.questions_id);
            ViewBag.Survey_id = new SelectList(db.Surveys, "survey_id", "survey_name", survey_has_Questions.Survey_id);
            return View(survey_has_Questions);
        }

        // GET: Survey_has_Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey_has_Questions survey_has_Questions = db.Survey_has_Questions.Find(id);
            if (survey_has_Questions == null)
            {
                return HttpNotFound();
            }
            ViewBag.questions_id = new SelectList(db.Questions, "questions_id", "question_text", survey_has_Questions.questions_id);
            ViewBag.Survey_id = new SelectList(db.Surveys, "survey_id", "survey_name", survey_has_Questions.Survey_id);
            return View(survey_has_Questions);
        }

        // POST: Survey_has_Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questions_id,Survey_id,answer")] Survey_has_Questions survey_has_Questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey_has_Questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.questions_id = new SelectList(db.Questions, "questions_id", "question_text", survey_has_Questions.questions_id);
            ViewBag.Survey_id = new SelectList(db.Surveys, "survey_id", "survey_name", survey_has_Questions.Survey_id);
            return View(survey_has_Questions);
        }

        // GET: Survey_has_Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey_has_Questions survey_has_Questions = db.Survey_has_Questions.Find(id);
            if (survey_has_Questions == null)
            {
                return HttpNotFound();
            }
            return View(survey_has_Questions);
        }

        // POST: Survey_has_Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey_has_Questions survey_has_Questions = db.Survey_has_Questions.Find(id);
            db.Survey_has_Questions.Remove(survey_has_Questions);
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
