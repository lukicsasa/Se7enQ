using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Se7enQ.Entities;
using Se7enQ.Data.UnitOfWork;
using Se7enQ.Common.Exceptions;
using Se7enQ.Common.Helpers;
using Se7enQ.Common.Models.Admin;

namespace Se7enQ.Core
{
    public class AdminManager
    {
        public User Login(string username, string password)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (!string.IsNullOrWhiteSpace(username))
                {
                    var user = uow.UserRepository.Find(u => (u.Username.ToLower().Trim() == username.ToLower().Trim()) || (u.Email.ToLower().Trim() == username.ToLower().Trim())).FirstOrDefault();
                    if (user == null) throw new ValidationException("User does not exist!");
                    if (!user.Admin) throw new ValidationException("You are not allowed to access this site!");
                    if (!PasswordHelper.ValidatePassword(password, user.Password))
                        throw new ValidationException("Wrong username or password!");
                    return user;
                }

                throw new ValidationException("You must provide login data!");
            }
        }

        public List<Calculation> GetCalculations()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Calculation> calculations = uow.CalculationRepository.GetAll();
                return calculations;
            }
        }

        public List<GeneralKnowledge> GetKnowledge()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<GeneralKnowledge> knowledge = uow.GeneralKnowledgeRepository.GetAll();
                return knowledge;
            }
        }

        public void DeleteQuestion(int id, string category)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                switch (category)
                {
                    case "General Knowledge":
                        GeneralKnowledge knowledge = uow.GeneralKnowledgeRepository.GetById(id);
                        uow.GeneralKnowledgeRepository.Delete(knowledge);
                        break;
                    case "Calculations":
                        Calculation calculation = uow.CalculationRepository.GetById(id);
                        uow.CalculationRepository.Delete(calculation);
                        break;
                    default: throw new ValidationException("Category does not exist!");
                }

                uow.Save();
            }
        }

        public void AddQuestion(QuestionModel question)
        {

            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    switch (question.Category)
                    {
                        case "Calculations":
                            Calculation calculation = new Calculation
                            {
                                Expression = question.Question,
                                CorrectResult = Int32.Parse(question.CorrectAnswer),
                                WrongResult1 = Int32.Parse(question.WrongAnswer1),
                                WrongResult2 = Int32.Parse(question.WrongAnswer2),
                                WrongResult3 = Int32.Parse(question.WrongAnswer3)
                            };
                            uow.CalculationRepository.Insert(calculation);
                            break;
                        case "General Knowledge":
                            GeneralKnowledge knowledge = new GeneralKnowledge
                            {
                                Question = question.Question,
                                CorrectAnswer = question.CorrectAnswer,
                                WrongAnswer1 = question.WrongAnswer1,
                                WrongAnswer2 = question.WrongAnswer2,
                                WrongAnswer3 = question.WrongAnswer3
                            };
                            uow.GeneralKnowledgeRepository.Insert(knowledge);
                            break;
                        default: throw new ValidationException("You cannot add question!");

                    }
                    uow.Save();
                }
            }
            catch (Exception)
            {
                throw new ValidationException("Please correct format.");
            }
        }

       

        #region private
        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        #endregion
    }
}
