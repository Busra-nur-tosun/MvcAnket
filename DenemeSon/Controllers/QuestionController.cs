using DenemeSon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeSon.Controllers
{
    public class QuestionController : Controller
    {
        AnketEntities db = new AnketEntities();
        public ActionResult Index()
        {
            var model = db.Question.ToList();
            return View(model);
        }
        public ActionResult Create(Question question)
        {
            if (question.QuestionLine != null)
            {
                question.CreateDate = DateTime.Now;
                question.CreateBy = "System";
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            var model = db.Question.Find(Id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(Question question)

        {
            db.Entry(question).State = System.Data.Entity.EntityState.Modified;
            db.Entry(question).Property(e => e.CreateBy).IsModified = false;//create by ve createdate değiişmesin
            db.Entry(question).Property(e => e.CreateDate).IsModified = false;

            question.ModifyDate = DateTime.Now;
            question.ModifyBy = "System Edit";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            var question = db.Question.Find(Id);
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}