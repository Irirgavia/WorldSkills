namespace DAL.Repositories.Interfaces
{
    using DAL.Entities;

    public interface ISkillRepository : IGenericRepository<SkillEntity>
    {
        SkillEntity GetSkillById(int id);

        SkillEntity GetSkillByName(string name);

        void CreateSkill(string name);

        void DeleteSkill(int id);

        void UpdateSkill(
            int id, 
            string name);
    }
}