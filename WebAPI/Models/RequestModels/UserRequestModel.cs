using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserRequestModel
    {
        [Required(ErrorMessage = "Укажите логин")]
        [MaxLength(30)]
        public string login { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        public string password { get; set; }
    }
}