//Bu kod parçası temel CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirir

using DenemeSon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeSon.Controllers
{
    public class PersonController : Controller
    {
       AnketEntities db = new AnketEntities();
        public ActionResult Index()
        {
            var model = db.Person.ToList();
            return View(model);
        }
        public ActionResult Create(Person person)
        {
            if(person.NameSurname!= null)
            {
                person.CreateDate = DateTime.Now;
                person.CreateBy = "system";
                db.Person.Add(person);
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
            var model = db.Person.Find(Id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(Person person)

        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.Entry(person).Property(e => e.CreateBy).IsModified = false;//create by ve createdate değiişmesin
            db.Entry(person).Property(e => e.CreateDate).IsModified = false;

            person.ModifyDate = DateTime.Now;
            person.ModifyBy = "System Edit";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            var person = db.Person.Find(Id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
