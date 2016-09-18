using Se7enQ.API.Helpers;
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
        [HttpGet]
        [TokenAuthorize]
        public UserModel FindOpponent()
        {
            User opponent = GameManager.FindOpponent(CurrentUser.Id);
            return Mapper.Map(opponent);
        }
    }
}