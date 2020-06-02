namespace DAL.Contexts.Initializers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities.Account;
    using DAL.Entities.Competition;

    public class CompetitionInitializer : DropCreateDatabaseIfModelChanges<CompetitionContext>
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

            context.Skills.Add(new SkillEntity("cooker"));
            context.SaveChanges();

            var skill = context.Skills.Where(s => s.Name == "cooker");
            context.Competitions.Add(
                new CompetitionEntity(
                    1,
                    new DateTime(2018, 2, 2),
                    new DateTime(2020, 10, 3),
                    new List<StageEntity>()));
            context.SaveChanges();

            context.Stages.Add(new StageEntity(1, 1, new List<TaskEntity>(), new List<int>() { 1 }));
            context.Stages.Add(new StageEntity(1, 2, new List<TaskEntity>(), new List<int>() { 1 }));
            context.Stages.Add(new StageEntity(1, 3, new List<TaskEntity>(), new List<int>() { 1 }));
            context.Stages.Add(new StageEntity(1, 4, new List<TaskEntity>(), new List<int>() { 1 }));
            context.SaveChanges();

            var address = new AddressEntity("rb", "grodno", "ogeshko", "32", "1", "notes");
            context.Tasks.Add(
                new TaskEntity(
                    1,
                    new DateTime(2018, 2, 21),
                    new TimeSpan(0, 4, 0),
                    "desc",
                    "link",
                    new List<AddressEntity>() { address },
                    new List<AnswerEntity>()));
            context.SaveChanges();

        }
    }
}