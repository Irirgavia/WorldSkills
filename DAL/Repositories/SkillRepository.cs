namespace DAL.Repositories
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class SkillRepository : GenericRepository<SkillEntity, CompetitionContext>, ISkillRepository
    {
        public SkillRepository(CompetitionContext context)
            : base(context)
        {
        }

        public SkillEntity GetSkillByName(string name)
        {
            return Context.Skills.AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
    }
}