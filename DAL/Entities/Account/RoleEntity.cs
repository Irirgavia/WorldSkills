namespace DAL.Entities.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RoleEntity : IIdentifier
    {
        public RoleEntity()
        {
        }

        public RoleEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}