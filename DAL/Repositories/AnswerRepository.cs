namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AnswerRepository : GenericRepository<AnswerEntity, CompetitionContext>, IAnswerRepository
    {
        public AnswerRepository(CompetitionContext context)
            : base(context)
        {
        }
    }
}