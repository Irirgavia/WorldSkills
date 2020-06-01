using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForJudge
{
    public class StageForAnswerResponseModel
    {
        public string Type { get; set; }

        public ICollection<TaskForAnswerResponseModel> Tasks { get; set; }

        public StageForAnswerResponseModel()
        {
            Tasks = new List<TaskForAnswerResponseModel>();
        }
    }
}