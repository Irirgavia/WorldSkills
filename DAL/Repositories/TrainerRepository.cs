namespace DAL.Repositories
{
    using System.Collections.Generic;
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
    }
}