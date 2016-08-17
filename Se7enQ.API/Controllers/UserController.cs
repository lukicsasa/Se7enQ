using Se7enQ.API.Helpers;
using Se7enQ.API.Models;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Se7enQ.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public UserModel GetUserById(int userId)
        {
            return Mapper.AutoMap<User, UserModel>(UserManager.GetUserById(userId));
        }

        [HttpGet]
        public int GetIncremented(int number)
        {
            return number++;
        }
    }
}