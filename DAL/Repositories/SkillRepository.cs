namespace DAL.Repositories
{
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class SkillRepository : GenericRepository<SkillEntity, CompetitionContext>, ISkillRepository
    {
        public SkillRepository(CompetitionContext context)
            : base(context)
        {
        }

        public SkillEntity GetSkillById(int id)
        {
            return Context.Skills.FirstOrDefault(x => x.Id == id);
        }

        public SkillEntity GetSkillByName(string name)
        {
            return Context.Skills.FirstOrDefault(x => x.Name == name);
        }

        public void CreateSkill(string name)
        {
            Context.Skills.Add(new SkillEntity(name));
        }

        public void DeleteSkill(int id)
        {
            var skill = this.GetSkillById(id);
            if (skill != null)
            {
                Context.Skills.Remove(skill);
            }
        }

        public void UpdateSkill(int id, string name)
        {
            var skill = this.GetSkillById(id);
            if (skill != null)
            {
                skill.Name = name;
            }
        }
    }
}