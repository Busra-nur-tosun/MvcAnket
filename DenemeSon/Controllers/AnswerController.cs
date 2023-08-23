using DenemeSon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeSon.Controllers
{
    public class AnswerController : Controller
    {
        AnketEntities db = new AnketEntities();
        public string Code { get; set; }
        public ActionResult Index()
        {
            var model = db.Answer.ToList();
            return View(model);
        }
        /*Bu işlev, yeni bir "Answer" nesnesi oluşturmayı amaçlıyor. Eğer bir "Code" parametresi verilmezse, "Person" verilerini çekip, bir kişi seçimi yapmayı sağlıyor. 
        Ayrıca "Question" verilerini alarak bir soru oluşturma işlemi gerçekleştiriliyor. Eğer "Code" verilirse, "Index" eylemine yönlendiriliyor.*/
        public ActionResult Create(string Code)
        {
            if (Code == null)
            {
                List<SelectListItem> personList = (from person in db.Person
                                                   where person.Code != Code
                                                   select new SelectListItem
                                                   {
                                                       Text = person.NameSurname,
                                                       Value = person.Code.ToString()
                                                   }).ToList();

                ViewBag.Person = new SelectList(personList.OrderBy(m => m.Text), "Value", "Text");
                var questionModel = db.Question.ToList();
                return View(questionModel);

            }
            else
            {
                return RedirectToAction("Index");
            }
             
           
          
        }
        /*Bu işlev, kullanıcıdan gelen "AnswerModel" verilerini alarak veritabanında ilgili "Answer" nesnesini güncelleme veya yeni 
        bir nesne oluşturma işlemini gerçekleştiriyor. Bu, kullanıcının verilen ay içerisinde daha önce cevapladığı bir "Answer" nesnesi varsa güncelleme
        yapmayı amaçlıyor. Aksi halde yeni bir "Answer" nesnesi oluşturup "AnswerLine" verilerini ekliyor.*/
        public string SendData(AnswerModel answerModel)

        {
            int? month = DateTime.Now.Month;
            var model = db.Answer.FirstOrDefault(m => m.PersonCode == answerModel.Code && m.UserCode == Code && m.CreateDate.Value.Month == month);

            if (model != null)
            {
                SaveAnswerLine(answerModel.Question, answerModel.Answer, model.Id);
            }
            else
            {
                Answer answer = new Answer();
                answer.PersonCode = answerModel.Code;
                answer.PersonName = answerModel.NameSurname;
              
                answer.CreateDate = DateTime.Now;
             
                db.Answer.Add(answer);
                db.SaveChanges();
                SaveAnswerLine(answerModel.Question, answerModel.Answer, answer.Id);
            }
            return "True";
        }
        /*Bu işlev, "AnswerLine" verilerini kaydetmeyi amaçlıyor. Eğer veritabanında ilgili "AnswerLine" nesnesi varsa güncelleme yapmayı,
        yoksa yeni bir nesne oluşturmayı sağlıyor.*/
        public void SaveAnswerLine(string question,string answer,int answerId)
        {
            var model = db.AnswerLine.FirstOrDefault(m => m.AnswerId == answerId && m.Question == question);

            if (model != null)
            {
                model.Answer = answer;// ilgili kayıt varsakayıtın cevabı değişecek
                db.SaveChanges();

            }
            else
            {
                AnswerLine answerLine = new AnswerLine();
                answerLine.AnswerId = answerId;
                answerLine.Answer = answer;
                answerLine.Question = question;
                db.AnswerLine.Add(answerLine);
                db.SaveChanges();
            }
           
        }    
        public ActionResult Detail(int? Id)
        {
            var model = db.AnswerLine.Where(m => m.AnswerId == Id).ToList();
            return View(model);
        }
    }
    
}
