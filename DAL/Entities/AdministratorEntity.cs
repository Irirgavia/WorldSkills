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
            User = user;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public ICollection<StageEntity> Stages { get; private set; }
    }
}