using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForParticipant
{
    public class StageForTaskResponseModel
    {
        public string Type { get; set; }
        public ICollection<TaskForTaskResponseModel> Tasks { get; set; }

        public StageForTaskResponseModel()
        {
            Tasks = new List<TaskForTaskResponseModel>();
        }
    }
}