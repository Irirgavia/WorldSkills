namespace DAL.Repositories.Account
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Account;
    using DAL.Repositories.Interfaces;

    public class AccountAddressRepository : GenericRepository<AddressEntity, AccountContext>, IAddressRepository
    {
        public AccountAddressRepository(AccountContext context)
            : base(context)
        {
        }

        public IEnumerable<AddressEntity> GetAddressesByPlace(
            string country, 
            string city = null,
            string street = null,
            string apartment = null,
            string house = null)
        {
            if (city != null && street != null && house != null && apartment != null)
            {
                return this.DbSet
                    .AsNoTracking()
                    .Where(
                    x => x.Country == country 
                         && x.City == city
                         && x.Street == street
                         && x.House == house
                         && x.Apartment == apartment);
            }

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