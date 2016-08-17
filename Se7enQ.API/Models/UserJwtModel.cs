using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.API.Models
{
    public class UserJwtModel
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }


        public List<string> Roles { get; set; } = new List<string>();
    }
}