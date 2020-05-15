namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AdministratorRepository : GenericRepository<AdministratorEntity, CompetitionContext>, IAdministratorRepository
    {
        public AdministratorRepository(CompetitionContext context)
            : base(context)
        {
        }
    }
}