using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels
{
    public class ResultForParticipantResponseModel
    {
        public string Skill { get; set; }

        public string Stage { get; set; }

        public string Date { get; set; }

        public int Mark { get; set; }
    }
}