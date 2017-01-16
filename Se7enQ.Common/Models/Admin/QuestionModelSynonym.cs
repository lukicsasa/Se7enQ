using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7enQ.Common.Models.Admin
{
    public class QuestionModelSynonym
    {
        public int Id { get; set; }
        public string CorrectAnswer1 { get; set; }
        public string CorrectAnswer2 { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string Category { get; set; }
    }
}
