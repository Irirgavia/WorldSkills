namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TaskEntity : IIdentifier
    {
        public TaskEntity()
        {
            Answers = new List<AnswerEntity>();
        }

        public TaskEntity(
            StageEntity stage,
            DateTime dateTime,
            TimeSpan time,
            AddressEntity address,
            string description,
            string requirement,
            ICollection<AnswerEntity> answers)
        {
            Stage = stage;
            DateTime = dateTime;
            Time = time;
            Address = address;
            Description = description;
            Requirement = requirement;
            Answers = answers;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public virtual StageEntity Stage { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public virtual AddressEntity Address { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirement { get; set; }

        [Required]
        public virtual ICollection<AnswerEntity> Answers { get; private set; }
    }
}