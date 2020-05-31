namespace DAL.Contexts.Initializers
{
    using System.Data.Entity;

    public class NotificationSystemInitializer : DropCreateDatabaseIfModelChanges<NotificationSystemContext>
    {
        protected override void Seed(NotificationSystemContext context)
        {
            //db.SaveChanges();
        }
    }
}