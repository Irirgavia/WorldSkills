namespace DAL
{
    using System;
    using System.Data.Entity;

    using DAL.Entities;

    public class CompetitionContextInitializer : DropCreateDatabaseIfModelChanges<CompetitionContext>
    {
        protected override void Seed(CompetitionContext db)
        {
            //db.SaveChanges();
        }
    }
}