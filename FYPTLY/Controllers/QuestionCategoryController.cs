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
    public class QuestionCategoryController : Controller
    {
        private FYPTLYEntities db = new FYPTLYEntities();

        // GET: QuestionCategory
        public ActionResult Index()
        {
            return View(db.Question_Category.ToList());
        }

        // GET: QuestionCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Category question_Category = db.Question_Category.Find(id);
            if (question_Category == null)
            {
                return HttpNotFound();
            }
            return View(question_Category);
        }

        // GET: QuestionCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question_Category_id,question_category_name")] Question_Category question_Category)
        {
            if (ModelState.IsValid)
            {
                db.Question_Category.Add(question_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question_Category);
        }

        // GET: QuestionCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Category question_Category = db.Question_Category.Find(id);
            if (question_Category == null)
            {
                return HttpNotFound();
            }
            return View(question_Category);
        }

        // POST: QuestionCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Question_Category_id,question_category_name")] Question_Category question_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question_Category);
        }

        // GET: QuestionCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_Category question_Category = db.Question_Category.Find(id);
            if (question_Category == null)
            {
                return HttpNotFound();
            }
            return View(question_Category);
        }

        // POST: QuestionCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question_Category question_Category = db.Question_Category.Find(id);
            db.Question_Category.Remove(question_Category);
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
