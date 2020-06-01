using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class MarkSaveRequestModel
    {
        public int answerId { get; set; }
        public float mark { get; set; }
    }
}