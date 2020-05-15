namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class ParticipantRepository : GenericRepository<ParticipantEntity, CompetitionContext>, IParticipantRepository
    {
        public ParticipantRepository(CompetitionContext context)
            : base(context)
        {
        }
    }
}