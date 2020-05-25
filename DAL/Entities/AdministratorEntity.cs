namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdministratorEntity : IIdentifier
    {
        public AdministratorEntity()
        {
            Stages = new List<StageEntity>();
        }

        public AdministratorEntity(int userEntityId, ICollection<StageEntity> stages)
        {
            UserEntityId = userEntityId;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int UserEntityId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}