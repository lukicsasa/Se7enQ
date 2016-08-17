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
    }
}
