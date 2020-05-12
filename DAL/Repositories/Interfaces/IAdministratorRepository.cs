namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IAdministratorRepository : IGenericRepository<AdministratorEntity>
    {
        AdministratorEntity GetAdministratorById(int id);

        void CreateAdministrator(UserEntity user, ICollection<StageEntity> stages);

        void DeleteAdministrator(int id);

        void UpdateAdministrator(int id, UserEntity user, ICollection<StageEntity> stages);
    }
}