namespace DAL.Contexts.Initializers
{
    using System.Data.Entity;

    using DAL.Entities.Competition;

    public class CompetitionInitializer : DropCreateDatabaseAlways<CompetitionContext>
    {
        protected override void Seed(CompetitionContext context)
        {
            context.Prizes.Add(new PrizeEntity("NonAwardWinning"));
            context.Prizes.Add(new PrizeEntity("FirstPlace"));
            context.Prizes.Add(new PrizeEntity("SecondPlace"));
            context.Prizes.Add(new PrizeEntity("ThirdPlace"));
            context.Prizes.Add(new PrizeEntity("IncentiveReward"));

            context.StageTypes.Add(new StageTypeEntity("Town"));
            context.StageTypes.Add(new StageTypeEntity("Region"));
            context.StageTypes.Add(new StageTypeEntity("Republic"));
            context.StageTypes.Add(new StageTypeEntity("International"));

            context.SaveChanges();
        }
    }
}