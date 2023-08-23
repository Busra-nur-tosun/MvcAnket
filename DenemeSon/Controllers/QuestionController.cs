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
        //Bu işlev, veritabanındaki tüm soru nesnelerini alarak bunları bir liste olarak görüntülemeyi amaçlıyor.
        //Bu liste daha sonra bir görünüme (View) iletiliyor.
        public ActionResult Index()
        {
            var model = db.Question.ToList();
            return View(model);
        }
        /*Bu işlev, yeni bir soru nesnesi oluşturmayı amaçlıyor. Eğer soru satırı (QuestionLine) boş değilse, yeni sorunun oluşturulma tarihini ve 
        kim tarafından oluşturulduğunu ayarlıyor, 
        veritabanına ekliyor ve ardından Index görünümüne yönlendiriyor.*/
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
        /*işlev, belirli bir sorunun düzenleme işlemini gerçekleştirmeyi amaçlıyor. 
        Eğer geçerli bir "Id" değeri sağlanırsa, ilgili soruyu bulup düzenlemek için veritabanından çekiyor ve düzenleme görünümüne yönlendiriyor.*/
        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            var model = db.Question.Find(Id);
            return View(model);

        }
        /*Bu işlev, düzenlenmiş bir soruyu veritabanında güncellemeyi amaçlıyor. Sorunun değiştirilmiş alanlarını güncelliyor, "CreateBy" ve "CreateDate" alanlarını 
        değiştirmemek için bu alanlara ait değişiklikleri geri alıyor ve düzenlenmiş sorunun güncellenmiş tarih ve kim tarafından güncellendiğini ayarlıyor.*/
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
        /*Bu işlev, belirli bir soruyu veritabanından silmeyi amaçlıyor. 
        Eğer geçerli bir "Id" sağlanırsa, ilgili soruyu buluyor, veritabanından siliyor ve Index görünümüne yönlendiriyor.*/
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
