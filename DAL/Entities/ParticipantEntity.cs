namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ParticipantEntity : IIdentifier
    {
        public ParticipantEntity()
        {
        }

        public ParticipantEntity(
            int userEntityId,
            int? trainerEntityId,
            AddressEntity address)
        {
            UserEntityId = userEntityId;
            TrainerEntityId = trainerEntityId;
            Address = address;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }

        public int? TrainerEntityId { get; set; }

        public int AddressEntityId { get; set; }

        [ForeignKey("AddressEntityId")]
        public virtual AddressEntity Address { get; set; }
    }
}