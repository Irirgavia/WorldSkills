namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;

    using DAL.Contexts;
    using DAL.Entities.Competition;
    using DAL.Repositories.Interfaces;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>, ICompetitionRepository
    {
        public CompetitionRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<CompetitionEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.StageTypeEntity))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))))
                .AsEnumerable();
        }

        public override IEnumerable<CompetitionEntity> Get(Func<CompetitionEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.StageTypeEntity))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))))
                .AsEnumerable()
                .Where(predicate);
        }

        public IEnumerable<CompetitionEntity> GetCompetitionsForRegistration(string stageTypeName)
        {
            return from competition in this.Context.Competitions
                    from stage in competition.StageEntities
                    where stage.StageTypeEntity.Name == stageTypeName
                    from task in stage.TaskEntities
                    where task.DateTimeBegin < DateTime.Now
                    select competition;
        }

        public override void Update(CompetitionEntity item)
        {
            var competition =  this.DbSet
                       .Include(c => c.SkillEntity)
                       .Include(c => c.StageEntities.Select(s => s.StageTypeEntity))
                       .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                       .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))))
                       .AsEnumerable()
                       .FirstOrDefault(c => c.Id == item.Id);

            competition.DateTimeBegin = item.DateTimeBegin;
            competition.DateTimeEnd = item.DateTimeEnd;
            competition.SkillEntityId = item.SkillEntityId;

            for (var k = 0; k < item.StageEntities.Count; k++)
            {
                competition.StageEntities[k].AccountIds = item.StageEntities[k].AccountIds;
                competition.StageEntities[k].CompetitionEntityId = item.StageEntities[k].CompetitionEntityId;
                competition.StageEntities[k].StageTypeEntityId = item.StageEntities[k].StageTypeEntityId;

                for (var j = 0; j < item.StageEntities[k].TaskEntities.Count; j++)
                {
                    competition.StageEntities[k].TaskEntities[j].DateTimeBegin = item.StageEntities[k].TaskEntities[j].DateTimeBegin;
                    competition.StageEntities[k].TaskEntities[j].DurationTime = item.StageEntities[k].TaskEntities[j].DurationTime;
                    competition.StageEntities[k].TaskEntities[j].Description = item.StageEntities[k].TaskEntities[j].Description;
                    competition.StageEntities[k].TaskEntities[j].Requirement = item.StageEntities[k].TaskEntities[j].Requirement;
                    competition.StageEntities[k].TaskEntities[j].StageEntityId = item.StageEntities[k].TaskEntities[j].StageEntityId;

                    for (var i = 0; i < item.StageEntities[k].TaskEntities[j].AddressEntities.Count; i++)
                    {
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].Apartment = item.StageEntities[k].TaskEntities[i].AddressEntities[i].Apartment;
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].City = item.StageEntities[k].TaskEntities[i].AddressEntities[i].City;
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].Country = item.StageEntities[k].TaskEntities[i].AddressEntities[i].Country;
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].House = item.StageEntities[k].TaskEntities[i].AddressEntities[i].House;
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].Notes = item.StageEntities[k].TaskEntities[i].AddressEntities[i].Notes;
                        competition.StageEntities[k] .TaskEntities[j].AddressEntities[i].Street = item.StageEntities[k].TaskEntities[i].AddressEntities[i].Street;
                    }

                    for (var i = 0; i < item.StageEntities[k].TaskEntities[j].AnswerEntities.Count; i++)
                    {
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].ResultEntity.Mark = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].ResultEntity.Mark;
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].ResultEntity.Notes = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].ResultEntity.Notes;
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].ResultEntity.PrizeEntityId = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].ResultEntity.PrizeEntityId;
                        
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].AccountEntityId = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].AccountEntityId;
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].Notes = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].Notes;
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].Notes = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].Notes;
                        competition.StageEntities[k].TaskEntities[j].AnswerEntities[i].TaskEntityId = item.StageEntities[k].TaskEntities[i].AnswerEntities[i].TaskEntityId;
                    }

                }
            }
        }
    }
}