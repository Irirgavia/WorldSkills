namespace WebAPI.ServiceProvider
{
    using BLL.Services;

    using BLL.Services.Interfaces;

    public static class ServiceProvider
    {
        private static ServiceModule serviceModule = new ServiceModule("AccountsDB", "CompetitionsDB", "SystemDB");

        private static IAdministratorService administratorService = null;

        private static IGuestService guestService = null;

        private static IJudgeService judgeService = null;

        private static IParticipantService participantService = null;

        public static IAdministratorService GetAdministratorService()
        {
            if (administratorService == null)
                administratorService = new AdministratorService(
                    serviceModule.AccountConnectionString,
                    serviceModule.CompetitionConnectionString,
                    serviceModule.NotificationConnectionString);
            return administratorService;
        }

        public static IGuestService GetGuestService()
        {
            if (guestService == null)
                guestService = new GuestService(serviceModule.AccountConnectionString,serviceModule.CompetitionConnectionString);
            return guestService;
        }

        public static IJudgeService GetJudgeService()
        {
            if (judgeService == null)
                judgeService = new JudgeService(serviceModule.CompetitionConnectionString, serviceModule.AccountConnectionString);
            return judgeService;
        }

        public static IParticipantService GetParticipantService()
        {
            if (participantService == null)
                participantService = new ParticipantService(serviceModule.AccountConnectionString, serviceModule.CompetitionConnectionString);
            return participantService;
        }
    }
}