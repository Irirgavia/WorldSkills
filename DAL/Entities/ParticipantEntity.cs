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
            int userEntityId,
            int? trainerEntityId,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages)
        {
            UserEntityId = userEntityId;
            TrainerEntityId = trainerEntityId;
            Address = address;
            Answers = answers;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }

        public int? TrainerEntityId { get; set; }

        [ForeignKey("TrainerEntityId")]
        public virtual TrainerEntity Trainer { get; set; }

        public int AddressEntityId { get; set; }

        [ForeignKey("AddressEntityId")]
        public virtual AddressEntity Address { get; set; }

        public virtual ICollection<AnswerEntity> Answers { get; private set; }

        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}