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
                //.Include(a => a.AccountEntityId.PersonalDataIdEntity.AddressEntity)
                //.Include(a => a.AccountEntityId.CredentialsIdEntity.RoleEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AnswerEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.ResultEntity)
                //.Include(a => a.AccountEntityId.PersonalDataIdEntity.AddressEntity)
                //.Include(a => a.AccountEntityId.CredentialsIdEntity.RoleEntity)
                .AsEnumerable();
        }
    }
}