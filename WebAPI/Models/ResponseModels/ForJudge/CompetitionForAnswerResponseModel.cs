using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForJudge
{
    public class CompetitionForAnswerResponseModel
    {
        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<StageForAnswerResponseModel> Stages { get; set; }

        public CompetitionForAnswerResponseModel()
        {
            Stages = new List<StageForAnswerResponseModel>();
        }

    }
}