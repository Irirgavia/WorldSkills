namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrainerEntity : IIdentifier
    {
        public TrainerEntity()
        {
            Participants = new List<ParticipantEntity>();
        }

        public TrainerEntity(
            UserEntity user, 
            ICollection<ParticipantEntity> participants)
        {
            User = user;
            Participants = participants;
        }

        [Key]
        public int Id { get; private set; }

        [Index(IsUnique = true)]
        public UserEntity User { get; set; }

        [Required]
        public ICollection<ParticipantEntity> Participants { get; private set; }
    }
}