﻿namespace DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Runtime.InteropServices;

    public class UserEntity : IIdentifier
    {
        public UserEntity()
        {
        }

        public UserEntity(
            string login,
            string password,
            Role role,
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
            Role = role;
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
        //[Index(IsUnique = true)]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
        /*
        public int? AdministratorId { get; set; }

        [ForeignKey("AdministratorId")]
        public virtual AdministratorEntity AdministratorEntity { get; set; }

        public int? JudgeId { get; set; }

        [ForeignKey("JudgeId")]
        public virtual JudgeEntity JudgeEntity { get; set; }

        public int? ParticipantId { get; set; }

        [ForeignKey("ParticipantId")]
        public virtual ParticipantEntity ParticipantEntity { get; set; }

        public int? TrainerId { get; set; }

        [ForeignKey("TrainerId")]
        public virtual TrainerEntity TrainerEntity { get; set; }
        */
        [Required]
        [Index("IX_FullNameAndBirthday", 1)]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [Index("IX_FullNameAndBirthday", 2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Index("IX_FullNameAndBirthday", 3)]
        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [Index("IX_FullNameAndBirthday", 4)]
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