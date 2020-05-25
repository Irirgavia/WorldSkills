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
            int userEntityId, 
            ICollection<StageEntity> stages)
        {
            UserEntityId = userEntityId;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}