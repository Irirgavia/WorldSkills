namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class StageRepository : GenericRepository<StageEntity, CompetitionContext>
    {
        public StageRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<StageEntity> Get(Func<StageEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.StageTypeEntity)
                .Include(s => s.TaskEntities.Select(t => t.AddressEntities))
                .Include(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)))
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<StageEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.StageTypeEntity)
                .Include(s => s.TaskEntities.Select(t => t.AddressEntities))
                .Include(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)))
                .AsEnumerable();
        }

        public override void Update(StageEntity item)
        {
            var stage = this.DbSet
                       .Include(s => s.StageTypeEntity)
                       .Include(s => s.TaskEntities.Select(t => t.AddressEntities))
                       .Include(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)))
                       .AsEnumerable()
                       .FirstOrDefault(s => s.Id == item.Id);

            stage.AccountIds = item.AccountIds;
            stage.CompetitionEntityId = item.CompetitionEntityId;
            stage.StageTypeEntityId = item.StageTypeEntityId;

            for (var j = 0; j < item.TaskEntities.Count; j++)
            {
                stage.TaskEntities[j].DateTimeBegin = item.TaskEntities[j].DateTimeBegin;
                stage.TaskEntities[j].DurationTime = item.TaskEntities[j].DurationTime;
                stage.TaskEntities[j].Description = item.TaskEntities[j].Description;
                stage.TaskEntities[j].Requirement = item.TaskEntities[j].Requirement;
                stage.TaskEntities[j].StageEntityId = item.TaskEntities[j].StageEntityId;

                for (var i = 0; i < item.TaskEntities[j].AddressEntities.Count; i++)
                {
                    stage.TaskEntities[j].AddressEntities[i].Apartment = item.TaskEntities[i].AddressEntities[i].Apartment;
                    stage.TaskEntities[j].AddressEntities[i].City = item.TaskEntities[i].AddressEntities[i].City;
                    stage.TaskEntities[j].AddressEntities[i].Country = item.TaskEntities[i].AddressEntities[i].Country; 
                    stage.TaskEntities[j].AddressEntities[i].House = item.TaskEntities[i].AddressEntities[i].House;
                    stage.TaskEntities[j].AddressEntities[i].Notes = item.TaskEntities[i].AddressEntities[i].Notes;
                    stage.TaskEntities[j].AddressEntities[i].Street = item.TaskEntities[i].AddressEntities[i].Street;
                }

                for (var i = 0; i < item.TaskEntities[j].AnswerEntities.Count; i++)
                {
                    stage.TaskEntities[j].AnswerEntities[i].ResultEntity.Mark = item.TaskEntities[i].AnswerEntities[i].ResultEntity.Mark;
                    stage.TaskEntities[j].AnswerEntities[i].ResultEntity.Notes = item.TaskEntities[i].AnswerEntities[i].ResultEntity.Notes;
                    stage.TaskEntities[j].AnswerEntities[i].ResultEntity.PrizeEntityId = item.TaskEntities[i].AnswerEntities[i].ResultEntity.PrizeEntityId;
                    
                    stage.TaskEntities[j].AnswerEntities[i].AccountEntityId = item.TaskEntities[i].AnswerEntities[i].AccountEntityId;
                    stage.TaskEntities[j].AnswerEntities[i].Notes = item.TaskEntities[i].AnswerEntities[i].Notes;
                    stage.TaskEntities[j].AnswerEntities[i].Notes = item.TaskEntities[i].AnswerEntities[i].Notes;
                    stage.TaskEntities[j].AnswerEntities[i].TaskEntityId = item.TaskEntities[i].AnswerEntities[i].TaskEntityId;
                }

            }
        }
    }
}