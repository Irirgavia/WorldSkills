using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class UserRequestModel
    {
        public string login { get; set; }
        public string password { get; set; }
    }
}