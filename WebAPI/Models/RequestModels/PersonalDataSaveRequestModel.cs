using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonalDataSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id пользователя")]
        [Range(1, Int32.MaxValue, ErrorMessage = "id пользователя не может быть отрицательным")]
        public int userId { get; set; }

        [Required(ErrorMessage = "Укажите фамилию пользователя")]
        [MaxLength(30)]
        public string surname { get; set; }

        [Required(ErrorMessage = "Укажите имя пользователя")]
        [MaxLength(30)]
        public string name { get; set; }

        [Required(ErrorMessage = "Укажите отчество пользователя")]
        [MaxLength(30)]
        public string patronymic { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения пользователя")]
        public string birthday { get; set; }

        [Required(ErrorMessage = "Укажите электронную почту пользователя")]
        [MaxLength(50)]
        public string mail { get; set; }

        [Required(ErrorMessage = "Укажите телефон пользователя")]
        [MaxLength(20)]
        public string telephone { get; set; }

        [Required(ErrorMessage = "Укажите страну проживания")]
        [MaxLength(25)]
        public string country { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [MaxLength(25)]
        public string city { get; set; }

        [Required(ErrorMessage = "Укажите улицу")]
        [MaxLength(25)]
        public string street { get; set; }

        [Required(ErrorMessage = "Укажите дом")]
        [MaxLength(10)]
        public string house { get; set; }
    }
}