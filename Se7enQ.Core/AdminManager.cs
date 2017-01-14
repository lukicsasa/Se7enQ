using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Se7enQ.Entities;
using Se7enQ.Data.UnitOfWork;
using Se7enQ.Common.Exceptions;
using Se7enQ.Common.Helpers;

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
    }
}
