namespace BLL.DTO.Account
{
    using System;

    public class PersonalDataDTO
    {
        public PersonalDataDTO()
        {
        }

        public PersonalDataDTO(
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Birthday = birthday;
            this.Photo = photo;
            this.Mail = mail;
            this.Telephone = telephone;
        }

        public int Id { get; private set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public string Photo { get; set; }

        public string Mail { get; set; }

        public string Telephone { get; set; }

        public AddressDTO Address { get; set; }
    }
}