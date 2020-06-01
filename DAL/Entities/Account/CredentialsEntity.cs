namespace DAL.Entities.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CredentialsEntity : IIdentifier
    {
        public CredentialsEntity()
        {
        }

        public CredentialsEntity(string login, string password, int roleEntityId)
        {
            this.Login = login;
            this.Password = password;
            this.RoleEntityId = roleEntityId;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public int RoleEntityId { get; set; }

        [ForeignKey("RoleEntityId")]
        public RoleEntity RoleEntity { get; set; }
    }
}