namespace DAL.Repositories.Interfaces
{
    using DAL.Entities;

    public interface ISkillRepository : IGenericRepository<SkillEntity>
    {
        SkillEntity GetSkillByName(string name);
    }
}