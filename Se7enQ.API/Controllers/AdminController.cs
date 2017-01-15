﻿using Se7enQ.API.Helpers;
using Se7enQ.API.Models;
using Se7enQ.API.Models.Admin;
using Se7enQ.API.Models.User;
using Se7enQ.Common.Models.Admin;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace Se7enQ.API.Controllers
{
    public class AdminController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public object Login(LoginModel model)
        {
            User user = AdminManager.Login(model.Username, model.Password);
            UserModel userModel = Mapper.Map(user);
            return new { User = userModel, Token = CreateLoginToken(user) };
        }

        [TokenAuthorize]
        [HttpGet]
        public TableQuestionsModel GetCalculations()
        {
            List<Calculation> calculations = AdminManager.GetCalculations();
            List<QuestionModel> questions = calculations.Select(a => new QuestionModel
            {
                Id = a.Id,
                Question = a.Expression,
                CorrectAnswer = a.CorrectResult.ToString(),
                WrongAnswer1 = a.WrongResult1.ToString(),
                WrongAnswer2 = a.WrongResult2.ToString(),
                WrongAnswer3 = a.WrongResult3.ToString(),
            }).ToList();

            return new TableQuestionsModel
            {
                Headers = new List<string> { "Id", "Expression", "Correct Result", "Wrong Result 1", "Wrong Result 2", "Wrong Result 3" },
                Questions = questions
            };
        }

        [TokenAuthorize]
        [HttpGet]
        public TableQuestionsModel GetKnowledge()
        {
            List<GeneralKnowledge> knowledge = AdminManager.GetKnowledge();
            List<QuestionModel> questions = knowledge.Select(a => new QuestionModel
            {
                Id = a.Id,
                Question = a.Question,
                CorrectAnswer = a.CorrectAnswer,
                WrongAnswer1 = a.WrongAnswer1,
                WrongAnswer2 = a.WrongAnswer2,
                WrongAnswer3 = a.WrongAnswer3,
            }).ToList();

            return new TableQuestionsModel
            {
                Headers = new List<string> { "Id", "Question", "Correct Answer", "Wrong Answer 1", "Wrong Answer 2", "Wrong Answer 3" },
                Questions = questions
            };
        }

        [TokenAuthorize]
        [HttpPost]
        public void DeleteQuestion(int id, string category)
        {
            AdminManager.DeleteQuestion(id, category);
        }

        [TokenAuthorize]
        [HttpPost]
        public void AddQuestion(QuestionModel question)
        {
            AdminManager.AddQuestion(question);
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