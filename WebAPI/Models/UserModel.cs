using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Role { get; set; }

        public AutorizationStatus Status { get; set; }
    }

    public enum AutorizationStatus
    {
        Success,
        NotFound,
        WrongPassword
    }
}