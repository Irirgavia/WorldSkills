namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class JudgeRepository : GenericRepository<JudgeEntity, CompetitionContext>, IJudgeRepository
    {
        public JudgeRepository(CompetitionContext context)
            : base(context)
        {
        }
    }
}