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
                .Include(x => x.Participants)
                .AsEnumerable();
        }

        public override IEnumerable<TrainerEntity> Get(Func<TrainerEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Participants)
                .AsEnumerable()
                .Where(predicate);
        }
    }
}