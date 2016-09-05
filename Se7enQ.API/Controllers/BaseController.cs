using Se7enQ.API.Models;
using Se7enQ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Se7enQ.API.Controllers
{
    public class BaseController : ApiController
    {
        internal UserJwtModel CurrentUser { get; set; }

        private UserManager userManager;
        public UserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = new UserManager());
            }
        }

        private TrainingManager trainingManager;
        public TrainingManager TrainingManager
        {
            get
            {
                return trainingManager ?? (trainingManager = new TrainingManager());
            }
        }
    }
}