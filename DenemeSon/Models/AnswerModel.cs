using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenemeSon.Models
{
    public class AnswerModel
    {
        public string Code { get; set; }// her cevabın benzersiz tanımlanması için 

        public string NameSurname { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
