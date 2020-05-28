namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class ParticipantRepository : GenericRepository<ParticipantEntity, CompetitionContext>, IParticipantRepository
    {
        public ParticipantRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<ParticipantEntity> Get(Func<ParticipantEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.Address)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<ParticipantEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.Address)
                .AsEnumerable();
        }
    }
}