namespace BLL
{
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    using Ninject.Modules;

    public class ServiceModule : NinjectModule
    {
        public readonly string ConnectionString;

        public ServiceModule(string connection)
        {
            this.ConnectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(this.ConnectionString);
        }
    }
}