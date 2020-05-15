namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ParticipantEntity : IIdentifier
    {
        public ParticipantEntity()
        {
            Answers = new List<AnswerEntity>();
            Stages = new List<StageEntity>();
        }

        public ParticipantEntity(
            UserEntity user,
            TrainerEntity trainer,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages)
        {
            User = user;
            Trainer = trainer;
            Address = address;
            Answers = answers;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public virtual UserEntity User { get; set; }

        public virtual TrainerEntity Trainer { get; set; }

        [Required]
        public virtual AddressEntity Address { get; set; }

        [Required]
        public virtual ICollection<AnswerEntity> Answers { get; private set; }

        [Required]
        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}