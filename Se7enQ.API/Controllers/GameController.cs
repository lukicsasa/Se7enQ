using Se7enQ.API.Helpers;
using Se7enQ.API.Models;
using Se7enQ.API.Models.User;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Se7enQ.API.Controllers
{
    public class GameController : BaseController
    {
        [TokenAuthorize]
        [HttpPost]
        public UserModel FindOpponent()
        {
            User opponent = GameManager.FindOpponent(CurrentUser.Id);
            return Mapper.Map(opponent);
        }


        [HttpPost]
        [TokenAuthorize]
        public object ReceiveQuestion(AnswerModel answer)
        {
            return GameManager.GetQuestion(CurrentUser.Id, answer.Answer,answer.Correct,answer.QuestionIndex);
        }

        [HttpPost]
        [TokenAuthorize]
        public void DeleteGame()
        {
            GameManager.DeleteGame(CurrentUser.Id);
        }
    }
}