namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class AccountDataSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите старый логин")]
        [MaxLength(30)]
        public string oldLogin { get; set; }

        [Required(ErrorMessage = "Укажите старый пароль")]
        public string oldPassword { get; set; }

        [Required(ErrorMessage = "Укажите новый логин")]
        [MaxLength(30)]
        public string newLogin { get; set; }

        [Required(ErrorMessage = "Укажите новый пароль")]
        public string newPassword { get; set; }
    }
}