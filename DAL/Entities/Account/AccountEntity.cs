namespace DAL.Entities.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AccountEntity : IIdentifier
    {
        public AccountEntity()
        {
        }

        public AccountEntity(PersonalDataEntity personalData, CredentialsEntity credentials, bool isMailNotificationTurnOn = true)
        {
            this.PersonalDataEntity = personalData;
            this.CredentialsEntity = credentials;
            this.IsMailNotificationTurnOn = isMailNotificationTurnOn;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public PersonalDataEntity PersonalDataEntity { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public CredentialsEntity CredentialsEntity { get; private set; }

        [Required]
        public bool IsMailNotificationTurnOn { get; set; }
    }
}