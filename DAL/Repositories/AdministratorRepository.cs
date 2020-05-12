namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AdministratorRepository : GenericRepository<AdministratorEntity, CompetitionContext>, IAdministratorRepository
    {
        public AdministratorRepository(CompetitionContext context)
            : base(context)
        {
        }

        public AdministratorEntity GetAdministratorById(int id)
        {
            return Context.Administrators.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAdministrator(UserEntity user, ICollection<StageEntity> stages)
        {
            Context.Administrators.Add(new AdministratorEntity(user, stages));
        }

        public void DeleteAdministrator(int id)
        {
            var admin = this.GetAdministratorById(id);
            if (admin != null)
            {
                Context.Administrators.Remove(admin);
            }
        }

        public void UpdateAdministrator(int id, UserEntity user, ICollection<StageEntity> stages)
        {
            var admin = this.GetAdministratorById(id);
            if (admin != null)
            {
                admin.User = user;
                admin.Stages.Clear();
                foreach (var stage in stages)
                {
                    admin.Stages.Add(stage);
                }
            }
        }
    }
}