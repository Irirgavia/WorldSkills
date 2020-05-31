namespace DAL.Contexts.Initializers
{
    using System.Data.Entity;

    public class CompetitionInitializer : DropCreateDatabaseIfModelChanges<CompetitionContext>
    {
        protected override void Seed(CompetitionContext context)
        {
            //db.SaveChanges();
        }
    }
}