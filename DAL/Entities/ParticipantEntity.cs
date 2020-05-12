namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        public UserEntity User { get; set; }

        public TrainerEntity Trainer { get; set; }

        [Required]
        public AddressEntity Address { get; set; }

        [Required]
        public ICollection<AnswerEntity> Answers { get; private set; }

        [Required]
        public ICollection<StageEntity> Stages { get; private set; }
    }
}