using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels
{
    public class NotificationResponseModel
    {
        public int Id { get; set; }

        public bool IsRead { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}