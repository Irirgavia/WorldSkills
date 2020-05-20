namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AdministratorRepository : GenericRepository<AdministratorEntity, CompetitionContext>, IAdministratorRepository
    {
        public AdministratorRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<AdministratorEntity> Get(Func<AdministratorEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.User)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<AdministratorEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}