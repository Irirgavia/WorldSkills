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

        public AdministratorEntity(UserEntity user, ICollection<StageEntity> stages)
        {
            this.User = user;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}