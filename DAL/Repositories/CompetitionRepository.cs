namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>, ICompetitionRepository
    {
        public CompetitionRepository(CompetitionContext context)
            : base(context)
        {

        }
    }
}