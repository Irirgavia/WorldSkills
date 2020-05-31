namespace DAL.Entities.Competition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DAL.Entities.Account;

    public class TaskEntity : IIdentifier
    {
        public TaskEntity()
        {
            this.AddressEntities = new List<AddressEntity>();
            this.AnswerEntities = new List<AnswerEntity>();
        }

        public TaskEntity(
            int stageEntityId,
            DateTime dateTimeBegin,
            TimeSpan durationTime,
            string description,
            string requirement,
            ICollection<AddressEntity> addressEntities,
            ICollection<AnswerEntity> answerEntities)
        {
            this.StageEntityId = stageEntityId;
            this.DateTimeBegin = dateTimeBegin;
            this.DurationTime = durationTime;
            this.Description = description;
            this.Requirement = requirement;
            this.AddressEntities = addressEntities;
            this.AnswerEntities = answerEntities;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int StageEntityId { get; set; }

        [Required]
        public DateTime DateTimeBegin { get; set; }

        [Required]
        public TimeSpan DurationTime { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirement { get; set; }

        public ICollection<AddressEntity> AddressEntities { get; set; }

        public ICollection<AnswerEntity> AnswerEntities { get; set; }
    }
}