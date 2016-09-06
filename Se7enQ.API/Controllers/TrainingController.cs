using Se7enQ.API.Helpers;
using Se7enQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Se7enQ.API.Controllers
{
    public class TrainingController : BaseController
    {
        [TokenAuthorize]
        [HttpGet]
        public List<WordDefinition> GetWordDefinitions()
        {
            return TrainingManager.GetWordDefinitions(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<Calculation> GetCalculations()
        {
            return TrainingManager.GetCalculations(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<GeneralKnowledge> GetGeneralKnowledge()
        {
            return TrainingManager.GetGeneralKnowledge(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<LogicArray> GetLogicArrays()
        {
            return TrainingManager.GetLogicArrays(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<Memory> GetMemory()
        {
            return TrainingManager.GetMemory(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<Projection> GetProjections()
        {
            return TrainingManager.GetProjections(CurrentUser.Id);
        }

        [TokenAuthorize]
        [HttpGet]
        public List<WordSynonym> GetWordSynonyms()
        {
            return TrainingManager.GetWordSynonyms(CurrentUser.Id);
        }
    }
}