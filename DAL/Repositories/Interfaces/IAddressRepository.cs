namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IAddressRepository : IGenericRepository<AddressEntity>
    {
        IEnumerable<AddressEntity> GetAddressesByPlace(string country, string city, string street, string house);
    }
}