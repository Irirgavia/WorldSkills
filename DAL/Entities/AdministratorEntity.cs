namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdministratorEntity : IIdentifier
    {
        public AdministratorEntity()
        {
        }

        public AdministratorEntity(int userEntityId)
        {
            UserEntityId = userEntityId;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int UserEntityId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [ForeignKey("UserEntityId")]
        public virtual UserEntity User { get; set; }
    }
}