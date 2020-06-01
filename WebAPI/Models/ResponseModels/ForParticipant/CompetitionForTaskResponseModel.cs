using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForParticipant
{
    public class CompetitionForTaskResponseModel
    {
        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<StageForTaskResponseModel> Stages { get; set; }

        public CompetitionForTaskResponseModel()
        {
            Stages = new List<StageForTaskResponseModel>();
        }
    }
}