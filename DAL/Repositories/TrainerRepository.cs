namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class TrainerRepository : GenericRepository<TrainerEntity,CompetitionContext>, ITrainerRepository
    {
        public TrainerRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<TrainerEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Participants.Select(p => p.Address))
                .Include(x => x.Participants.Select(p => p.User))
                .AsEnumerable();
        }

        public override IEnumerable<TrainerEntity> Get(Func<TrainerEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Participants.Select(p => p.Address))
                .Include(x => x.Participants.Select(p => p.User))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}