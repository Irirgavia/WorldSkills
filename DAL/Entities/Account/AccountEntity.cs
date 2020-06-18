namespace DAL.Entities.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AccountEntity : IIdentifier
    {
        public AccountEntity()
        {
        }

        public AccountEntity(int personalDataId, int credentialsId, bool isMailNotificationTurnOn = true)
        {
            this.PersonalDataEntityId = personalDataId;
            this.CredentialsEntityId = credentialsId;
            this.IsMailNotificationTurnOn = isMailNotificationTurnOn;
        }

        public AccountEntity(
            PersonalDataEntity personalData,
            CredentialsEntity credentials,
            bool isMailNotificationTurnOn = true)
        {
            this.PersonalDataIdEntity = personalData;
            this.CredentialsIdEntity = credentials;
            this.IsMailNotificationTurnOn = isMailNotificationTurnOn;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public int PersonalDataEntityId { get; set; }

        [ForeignKey("PersonalDataEntityId")]
        public PersonalDataEntity PersonalDataIdEntity { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public int CredentialsEntityId { get; private set; }

        [ForeignKey("CredentialsEntityId")]
        public CredentialsEntity CredentialsIdEntity { get; private set; }

        [Required]
        public bool IsMailNotificationTurnOn { get; set; }

        public IList<int> StageIds { get; set; }
    }
}