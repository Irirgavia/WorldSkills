namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using System.Data.Entity;
    using DAL.Repositories.Interfaces;

    public class AnswerRepository : GenericRepository<AnswerEntity, CompetitionContext>, IAnswerRepository
    {
        public AnswerRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<AnswerEntity> Get(Func<AnswerEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.Result)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AnswerEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.Result)
                .AsEnumerable();
        }
    }
}