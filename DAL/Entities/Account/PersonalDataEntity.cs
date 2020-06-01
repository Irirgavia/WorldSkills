namespace DAL.Entities.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PersonalDataEntity : IIdentifier
    {
        public PersonalDataEntity()
        {
        }

        public PersonalDataEntity(
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            int addressId)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Birthday = birthday;
            this.Photo = photo;
            this.Mail = mail;
            this.Telephone = telephone;
            this.AddressEntityId = addressId;
        }

        public PersonalDataEntity(
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            AddressEntity address)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Birthday = birthday;
            this.Photo = photo;
            this.Mail = mail;
            this.Telephone = telephone;
            this.AddressEntity = address;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Patronymic { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        [MaxLength(20)]
        public string Mail { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Required]
        public int AddressEntityId { get; set; }

        [ForeignKey("AddressEntityId")]
        public AddressEntity AddressEntity { get; set; }
    }
}