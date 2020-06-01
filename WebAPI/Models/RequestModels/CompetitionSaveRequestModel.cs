using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class CompetitionSaveRequestModel
    {
        public int competitionId { get; set; }

        public string skill { get; set; }

        public string dateOfBegin { get; set; }

        public string dateOfEnd { get; set; }
    }
}