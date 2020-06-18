namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class AnswerRepository : GenericRepository<AnswerEntity, CompetitionContext>
    {
        public AnswerRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<AnswerEntity> Get(Func<AnswerEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.ResultEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AnswerEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.ResultEntity)
                .AsEnumerable();
        }

        public override void Update(AnswerEntity item)
        {
            var answer = this.DbSet
                .Include(a => a.ResultEntity)
                .AsEnumerable()
                .FirstOrDefault(a => a.Id == item.Id);

            answer.ResultEntity.Mark = item.ResultEntity.Mark;
            answer.ResultEntity.Notes = item.ResultEntity.Notes;
            answer.ResultEntity.PrizeEntityId = item.ResultEntity.PrizeEntityId;
            answer.Notes = item.Notes;
            answer.ProjectLink = item.ProjectLink;
            answer.TaskEntityId = item.TaskEntityId;
            answer.AccountEntityId = item.AccountEntityId;
        }
    }
}