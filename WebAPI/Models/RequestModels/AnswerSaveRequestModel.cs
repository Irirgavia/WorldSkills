using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class AnswerSaveRequestModel
    {
        public int taskId { get; set; }
        
        public int participantId { get; set; }

        public string projectLink { get; set; }
    }
}