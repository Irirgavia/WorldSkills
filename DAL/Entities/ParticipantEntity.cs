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
            this.UserEntity = user;
            Trainer = trainer;
            Address = address;
            Answers = answers;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity UserEntity { get; set; }

        public int? TrainerId { get; set; }

        [ForeignKey("TrainerId")]
        public virtual TrainerEntity Trainer { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual AddressEntity Address { get; set; }

        public virtual ICollection<AnswerEntity> Answers { get; private set; }

        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}