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
            int userEntityId, 
            ICollection<ParticipantEntity> participants)
        {
            UserEntityId = userEntityId;
            Participants = participants;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<ParticipantEntity> Participants { get; private set; }
    }
}