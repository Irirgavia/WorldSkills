namespace WebAPI.ServiceProvider
{
    using BLL.Services;

    using BLL.Services.Interfaces;

    public static class ServiceProvider
    {
        private static string connection = "CompetitionContext";

        private static IAdministratorService administratorService = null;

        private static IGuestService guestService = null;

        private static IJudgeService judgeService = null;

        private static IParticipantService participantService = null;

        private static ITrainerService trainerService = null;

        public static IAdministratorService GetAdministratorService()
        {
            if (administratorService == null)
                administratorService = new AdministratorService(connection);
            return administratorService;
        }

        public static IGuestService GetGuestService()
        {
            if (guestService == null)
                guestService = new GuestService(connection);
            return guestService;
        }

        public static IJudgeService GetJudgeService()
        {
            if (judgeService == null)
                judgeService = new JudgeService(connection);
            return judgeService;
        }

        public static IParticipantService GetParticipantService()
        {
            if (participantService == null)
                participantService = new ParticipantService(connection);
            return participantService;
        }

        public static ITrainerService GetTrainerService()
        {
            if (trainerService == null)
                trainerService = new TrainerService(connection);
            return trainerService;
        }
    }
}