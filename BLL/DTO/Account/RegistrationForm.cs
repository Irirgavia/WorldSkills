namespace BLL.DTO.Account
{
    using System;

    public class RegistrationForm
    {
        public RegistrationForm()
        {
        }

        public PersonalDataDTO PersonalData { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Skill { get; set; }
    }
}