using Se7enQ.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.API.Models.Admin
{
    public class TableQuestionsModel
    {
        public List<string> Headers { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}