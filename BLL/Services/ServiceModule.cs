namespace BLL.Services
{
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    using Ninject.Modules;

    public class ServiceModule : NinjectModule
    {
        public readonly string AccountConnectionString;
        public readonly string CompetitionConnectionString;
        public readonly string NotificationConnectionString;


        public ServiceModule(string accountConnection, string competitionConnection, string notificationConnection)
        {
            this.AccountConnectionString = accountConnection;
            this.CompetitionConnectionString = competitionConnection;
            this.NotificationConnectionString = notificationConnection;
        }

        public override void Load()
        {
            this.Bind<IAccountUnitOfWork>().To<AccountUnitOfWork>().WithConstructorArgument(this.AccountConnectionString);
            this.Bind<ICompetitionUnitOfWork>().To<CompetitionUnitOfWork>().WithConstructorArgument(this.CompetitionConnectionString);
            this.Bind<ISystemUnitOfWork>().To<DAL.UnitOfWorks.SystemUnitOfWork>().WithConstructorArgument(this.NotificationConnectionString);
        }
    }
}