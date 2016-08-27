using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.API.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Playing { get; set; }
    }
}