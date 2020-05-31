namespace DAL.Repositories.Account
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Account;
    using DAL.Repositories.Interfaces;

    public class AddressRepository : GenericRepository<AddressEntity, AccountContext>, IAddressRepository
    {
        public AddressRepository(AccountContext context)
            : base(context)
        {
        }

        public IEnumerable<AddressEntity> GetAddressesByPlace(string country, string city = null, string street = null, string house = null)
        {
            if (city != null && street != null && house != null)
            {
                return this.DbSet
                    .AsNoTracking()
                    .Where(
                    x => x.Country == country 
                         && x.City == city
                         && x.Street == street
                         && x.House == house);
            }

            if (city != null && street != null)
            {
                return this.DbSet
                    .AsNoTracking()
                    .Where(
                    x => x.Country == country
                         && x.City == city
                         && x.Street == street);
            }

            if (city != null)
            {
                return this.DbSet
                    .AsNoTracking()
                    .Where(
                    x => x.Country == country
                         && x.City == city);
            }

            return this.DbSet
                .AsNoTracking()
                .Where(x => x.Country == country);
        }
    }
}