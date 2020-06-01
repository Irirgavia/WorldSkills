using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForAdmin
{
    public class CompetitionResponseModel
    {
        public int Id { get; set; }

        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<StageResponseModel> Stages { get; set; }

        public CompetitionResponseModel()
        {
            Stages = new List<StageResponseModel>();
        }
    }
}