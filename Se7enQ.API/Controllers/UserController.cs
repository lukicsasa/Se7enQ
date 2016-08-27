using Se7enQ.API.Helpers;
using Se7enQ.API.Models;
using Se7enQ.API.Models.User;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace Se7enQ.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        [TokenAuthorize]
        public UserModel GetUserById(int userId)
        {
            return Mapper.Map(UserManager.GetUserById(userId));
        }

        [AllowAnonymous]
        [HttpPost]
        public object Login(LoginModel model)
        {
            User user = UserManager.Login(model.Username, model.Password);
            UserModel userModel = Mapper.Map(user);
            return new { User = userModel, Token = CreateLoginToken(user) };
        }

        [AllowAnonymous]
        [HttpPost]
        public UserModel Register(UserModel model)
        {
            User user = UserManager.Register(model.Username, model.Password,model.FirstName,model.LastName,model.Email, model.ImageUrl);
            UserModel userModel = Mapper.Map(user);
            return userModel;
        }

        #region Private methods

        [NonAction]
        private string CreateLoginToken(User user)
        {
            UserJwtModel userModel = Mapper.AutoMap<User, UserJwtModel>(user);
            userModel.ExpirationDate = DateTime.UtcNow.AddDays(1);

            string secretKey = WebConfigurationManager.AppSettings["JwtSecret"];
            string token = JWT.JsonWebToken.Encode(userModel, secretKey, JWT.JwtHashAlgorithm.HS256);
            return token;
        }

        #endregion
    }
}