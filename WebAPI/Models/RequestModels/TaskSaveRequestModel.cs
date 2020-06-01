using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class TaskSaveRequestModel
    {
        public int competitionId { get; set; }

        public int stageId { get; set; }

        public int id { get; set; }

        public string taskDateOfBegin { get; set; }

        public string taskDateOfEnd { get; set; }

        public string description { get; set; }

        public string addresses { get; set; }
    }
}