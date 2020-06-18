namespace BLL.DTO.Account
{
    using System.Collections.Generic;

    public class AccountDTO
    {
        public AccountDTO()
        {
        }

        public AccountDTO(
            PersonalDataDTO personalData,
            CredentialsDTO credentials,
            bool isMailNotificationTurnOn)
        {
            this.PersonalData = personalData;
            this.Credentials = credentials;
            this.IsMailNotificationTurnOn = isMailNotificationTurnOn;
        }

        public int Id { get; private set; }

        public PersonalDataDTO PersonalData { get; set; }

        public CredentialsDTO Credentials { get; set; }

        public bool IsMailNotificationTurnOn { get; set; }

        public IList<int> StageIds { get; set; }
    }
}