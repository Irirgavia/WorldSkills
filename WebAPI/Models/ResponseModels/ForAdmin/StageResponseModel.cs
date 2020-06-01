using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels.ForAdmin
{
    public class StageResponseModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<TaskResponseModel> Tasks { get; set; }

        public StageResponseModel()
        {
            Tasks = new List<TaskResponseModel>();
        }
    }
}