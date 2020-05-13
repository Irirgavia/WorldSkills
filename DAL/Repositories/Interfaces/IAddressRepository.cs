namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        AddressEntity GetAddressById(int id);

        IEnumerable<AddressEntity> GetAddressesByPlace(string country, string city, string street, string house);

        void CreateAddress(
            string country, 
            string city,
            string street, 
            string house, 
            string notes);

        void DeleteAddress(int id);

        void UpdateAddress(
            int id, 
            string country, 
            string city,
            string street,
            string house,
            string note);
    }
}