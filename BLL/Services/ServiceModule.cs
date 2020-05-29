namespace BLL.Services
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
            this.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(this.ConnectionString);
        }
    }
}