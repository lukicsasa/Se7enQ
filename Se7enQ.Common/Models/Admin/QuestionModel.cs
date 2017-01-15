using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.Common.Models.Admin
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string Category { get; set; }
    }
}