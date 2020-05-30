using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels
{
    public class UserResponseModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }
    }
}