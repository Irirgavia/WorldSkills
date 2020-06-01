namespace DAL.Contexts.Initializers
{
    using System.Data.Entity;

    public class SystemInitializer : DropCreateDatabaseAlways<SystemContext>
    {
        protected override void Seed(SystemContext context)
        {
            context.SaveChanges();
        }
    }
}