using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class StageSaveRequestModel
    {
        public int competitionId { get; set; }

        public int id { get; set; }

        public string stagetype { get; set; }

    }
}