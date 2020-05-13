namespace DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    public class UserEntity : IIdentifier
    {
        public UserEntity()
        {
        }

        public UserEntity(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards)
        {
            Login = login;
            Password = password;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
            Photo = photo;
            Mail = mail;
            Telephone = telephone;
            Awards = awards;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Telephone { get; set; }

        public string Awards { get; set; }
    }
}