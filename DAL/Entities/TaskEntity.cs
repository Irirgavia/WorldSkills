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
            Addresses = new List<AddressEntity>();
            Answers = new List<AnswerEntity>();
        }

        public TaskEntity(
            int stageEntityId,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressEntity> addresses,
            ICollection<AnswerEntity> answers)
        {
            StageEntityId = stageEntityId;
            DateTime = dateTime;
            Time = time;
            Description = description;
            Requirement = requirement;
            Addresses = addresses;
            Answers = answers;
        }

        [Key]
        public int Id { get; private set; }

        public int StageEntityId { get; set; }

        //[ForeignKey("StageEntityId")]
        //public virtual StageEntity Stage { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirement { get; set; }

        public virtual ICollection<AddressEntity> Addresses { get; set; }

        public virtual ICollection<AnswerEntity> Answers { get; set; }
    }
}