using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonalDataSaveByAdminRequestModel
    {
        [Required(ErrorMessage = "Укажите id пользователя")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id пользователя не может быть отрицательным")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите роль пользователя")]
        [MaxLength(30)]
        public string Role { get; set; }

        [Required(ErrorMessage = "Укажите фамилию пользователя")]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Укажите имя пользователя")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите отчество пользователя")]
        [MaxLength(30)]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения пользователя")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Укажите электронную почту пользователя")]
        [MaxLength(50)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Укажите телефон пользователя")]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Укажите страну проживания")]
        [MaxLength(25)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [MaxLength(25)]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите улицу")]
        [MaxLength(25)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Укажите дом")]
        [MaxLength(10)]
        public string House { get; set; }

        [Required(ErrorMessage = "Укажите квартиру")]
        [MaxLength(10)]
        public string Apartment { get; set; }
    }
}