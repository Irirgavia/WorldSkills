namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AddressRepository : GenericRepository<AddressEntity, CompetitionContext>, IAddressRepository
    {
        public AddressRepository(CompetitionContext context)
            : base(context)
        {
        }

        public IEnumerable<AddressEntity> GetAddressesByPlace(string country, string city = null, string street = null, string house = null)
        {
            if (city != null && street != null && house != null)
            {
                return Context.Addresses.AsNoTracking().Where(
                    x => x.Country == country 
                         && x.City == city
                         && x.Street == street
                         && x.House == house);
            }

            if (city != null && street != null)
            {
                return Context.Addresses.AsNoTracking().Where(
                    x => x.Country == country
                         && x.City == city
                         && x.Street == street);
            }

            if (city != null)
            {
                return Context.Addresses.AsNoTracking().Where(
                    x => x.Country == country
                         && x.City == city);
            }

            return Context.Addresses.AsNoTracking().Where(x => x.Country.Equals(country));
        }
    }
}