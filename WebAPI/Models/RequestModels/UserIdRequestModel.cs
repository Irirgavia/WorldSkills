namespace WebAPI.Models.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserIdRequestModel
    {
        [Required(ErrorMessage = "Укажите id пользователя")]
        [Range(1, Int32.MaxValue, ErrorMessage = "id пользователя не может быть отрицательным")]
        public int id { get; set; }
    }
}