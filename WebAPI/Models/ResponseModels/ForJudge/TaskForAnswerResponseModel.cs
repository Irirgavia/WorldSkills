using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForJudge
{
    public class TaskForAnswerResponseModel
    {
        public string TaskDateOfBegin { get; set; }

        public string TaskDateOfEnd { get; set; }

        public string Description { get; set; }

        public ICollection<AnswerForAnswerResponseModel> Answers { get; set; }

        public TaskForAnswerResponseModel()
        {
            Answers = new List<AnswerForAnswerResponseModel>();
        }
    }
}