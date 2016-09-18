using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.API.Models
{
    public class AnswerModel
    {
        public string Answer { get; set; }
        public bool Correct { get; set; }
        public int QuestionIndex { get; set; }
    }
}