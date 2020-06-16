namespace WebAPI.ServiceProvider
{
    using BLL.Services;

    using BLL.Services.Interfaces;

    public static class ServiceProvider
    {
        private static ServiceModule serviceModule = new ServiceModule(
            "AccountsDBconnection",
            "CompetitionsDBconnection",
            "SystemDBconnection");

        private static IAccountService accountService = null;

        private static ICompetitionService competitionService = null;

        private static ISystemService systemService = null;

        public static IAccountService GetAccountService()
        {
            if (accountService == null)
                accountService = new AccountService(serviceModule.AccountConnectionString);
            return accountService;
        }

        public static ICompetitionService GetCompetitionService()
        {
            if (competitionService == null)
                competitionService = new CompetitionService(serviceModule.CompetitionConnectionString);
            return competitionService;
        }

        public static ISystemService GetSystemService()
        {
            if (systemService == null)
                systemService = new SystemService(serviceModule.NotificationConnectionString);
            return systemService;
        }
    }
}