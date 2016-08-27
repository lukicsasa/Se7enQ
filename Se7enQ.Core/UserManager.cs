using Se7enQ.Common.Exceptions;
using Se7enQ.Common.Helpers;
using Se7enQ.Data.UnitOfWork;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7enQ.Core
{
    public class UserManager
    {
        public User GetUserById(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.UserRepository.Find(a => a.Id == userId).FirstOrDefault();
            }
        }

        public User Login(string username, string password)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (!string.IsNullOrWhiteSpace(username))
                {
                    var user = uow.UserRepository.Find(u => (u.Username.ToLower().Trim() == username.ToLower().Trim()) || (u.Email.ToLower().Trim() == username.ToLower().Trim())).FirstOrDefault();

                    if (user == null) throw new ValidationException("Wrong username or password!");

                    if (!PasswordHelper.ValidatePassword(password, user.Password))
                        throw new ValidationException("Wrong username or password!");
                    return user;
                }

                throw new ValidationException("You must provide login data!");
            }
        }

        public User Register(string username, string password,string firstName,string lastName, string email, string imageUrl)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var existingUsers = uow.UserRepository.Find(u => u.Username == username || u.Email == email);
                    if (existingUsers.Any())
                    {
                        throw new ValidationException("Account is already taken!");
                    }
                }

                if (!string.IsNullOrEmpty(password))
                {
                    password = PasswordHelper.CreateHash(password);
                }

                var user = new User
                {
                    DateCreated = DateTime.UtcNow,
                    Username = username,
                    Password = password,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Playing = false,
                    ImageUrl = imageUrl
                };

                uow.UserRepository.Insert(user);
                uow.Save();

                return user;
            }
        }
    }
}
