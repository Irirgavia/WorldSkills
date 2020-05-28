namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JudgeEntity : IIdentifier
    {
        public JudgeEntity()
        {
        }

        public JudgeEntity(int userEntityId)
        {
            UserEntityId = userEntityId;
        }

        [Key]
        public int Id { get; private set; }

        public int UserEntityId { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }
    }
}