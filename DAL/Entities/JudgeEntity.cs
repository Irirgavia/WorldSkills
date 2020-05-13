namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JudgeEntity : IIdentifier
    {
        public JudgeEntity()
        {
            Stages = new List<StageEntity>();
        }

        public JudgeEntity(
            UserEntity user, 
            ICollection<StageEntity> stages)
        {
            User = user;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public UserEntity User { get; set; }

        [Required]
        public ICollection<StageEntity> Stages { get; private set; }
    }
}