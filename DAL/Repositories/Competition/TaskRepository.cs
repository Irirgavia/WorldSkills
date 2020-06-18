namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class TaskRepository : GenericRepository<TaskEntity, CompetitionContext>
    {
        public TaskRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<TaskEntity> GetAll()
        {
            return this.DbSet.AsNoTracking().Include(c => c.AddressEntities)
                       .Include(c => c.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)).AsEnumerable();
        }

        public override IEnumerable<TaskEntity> Get(Func<TaskEntity, bool> predicate)
        {
            return this.DbSet.AsNoTracking().Include(c => c.AddressEntities)
                       .Include(c => c.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)).AsEnumerable()
                       .Where(predicate);
        }

        public override void Update(TaskEntity item)
        {
            var task = this.DbSet.Include(c => c.AddressEntities)
                           .Include(c => c.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity)).AsEnumerable()
                           .FirstOrDefault(t => t.Id == item.Id);

            for (var i = 0; i < item.AddressEntities.Count; i++)
            {
                task.AddressEntities[i].Apartment = item.AddressEntities[i].Apartment;
                task.AddressEntities[i].City = item.AddressEntities[i].City;
                task.AddressEntities[i].Country = item.AddressEntities[i].Country;
                task.AddressEntities[i].House = item.AddressEntities[i].House;
                task.AddressEntities[i].Notes = item.AddressEntities[i].Notes;
                task.AddressEntities[i].Street = item.AddressEntities[i].Street;
            }

            for (var i = 0; i < item.AnswerEntities.Count; i++)
            {
                task.AnswerEntities[i].ResultEntity.Mark = item.AnswerEntities[i].ResultEntity.Mark;
                task.AnswerEntities[i].ResultEntity.Notes = item.AnswerEntities[i].ResultEntity.Notes;
                task.AnswerEntities[i].ResultEntity.PrizeEntityId = item.AnswerEntities[i].ResultEntity.PrizeEntityId;

                task.AnswerEntities[i].AccountEntityId = item.AnswerEntities[i].AccountEntityId;
                task.AnswerEntities[i].Notes = item.AnswerEntities[i].Notes;
                task.AnswerEntities[i].Notes = item.AnswerEntities[i].Notes;
                task.AnswerEntities[i].TaskEntityId = item.AnswerEntities[i].TaskEntityId;
            }

            task.DateTimeBegin = item.DateTimeBegin;
            task.DurationTime = item.DurationTime;
            task.Description = item.Description;
            task.Requirement = item.Requirement;
            task.StageEntityId = item.StageEntityId;

        }
    }
}