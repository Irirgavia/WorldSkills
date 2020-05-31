namespace DAL.Contexts.Initializers
{
    using System.Data.Entity;

    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            //db.SaveChanges();
        }
    }
}