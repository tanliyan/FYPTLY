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
    public class QuestionsController : Controller
    {
        private FYPTLYEntities db = new FYPTLYEntities();

        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Medical_Test).Include(q => q.Question_Category);
            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.Medical_Test_Medical_Test_id = new SelectList(db.Medical_Test, "Medical_Test_id", "test_name");
            ViewBag.Question_Category_id = new SelectList(db.Question_Category, "Question_Category_id", "question_category_name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questions_id,question_text,mcq,question_option,Question_Category_id,Medical_Test_Medical_Test_id")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Medical_Test_Medical_Test_id = new SelectList(db.Medical_Test, "Medical_Test_id", "test_name", question.Medical_Test_Medical_Test_id);
            ViewBag.Question_Category_id = new SelectList(db.Question_Category, "Question_Category_id", "question_category_name", question.Question_Category_id);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Medical_Test_Medical_Test_id = new SelectList(db.Medical_Test, "Medical_Test_id", "test_name", question.Medical_Test_Medical_Test_id);
            ViewBag.Question_Category_id = new SelectList(db.Question_Category, "Question_Category_id", "question_category_name", question.Question_Category_id);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questions_id,question_text,mcq,question_option,Question_Category_id,Medical_Test_Medical_Test_id")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Medical_Test_Medical_Test_id = new SelectList(db.Medical_Test, "Medical_Test_id", "test_name", question.Medical_Test_Medical_Test_id);
            ViewBag.Question_Category_id = new SelectList(db.Question_Category, "Question_Category_id", "question_category_name", question.Question_Category_id);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
