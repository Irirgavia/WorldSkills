namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>
    {
        public CompetitionRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<CompetitionEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntities))))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.AccountEntity.PersonalDataEntity.AddressEntity))))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.AccountEntity.CredentialsEntity.RoleEntity))))
                .Include(c => c.StageEntities.Select(s => s.AccountEntities.Select(a => a.PersonalDataEntity.AddressEntity)))
                .Include(c => c.StageEntities.Select(s => s.AccountEntities.Select(a => a.CredentialsEntity.RoleEntity)))
                .AsEnumerable();
        }

        public override IEnumerable<CompetitionEntity> Get(Func<CompetitionEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntities))))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.AccountEntity.PersonalDataEntity.AddressEntity))))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.AccountEntity.CredentialsEntity.RoleEntity))))
                .Include(c => c.StageEntities.Select(s => s.AccountEntities.Select(a => a.PersonalDataEntity.AddressEntity)))
                .Include(c => c.StageEntities.Select(s => s.AccountEntities.Select(a => a.CredentialsEntity.RoleEntity)))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}