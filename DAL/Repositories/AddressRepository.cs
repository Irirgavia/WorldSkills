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
                return Context.Addresses.Where(
                    x => x.Country.Equals(country) 
                         && x.City.Equals(city) 
                         && x.Street.Equals(street)
                         && x.House.Equals(house));
            }

            if (city != null && street != null)
            {
                return Context.Addresses.Where(
                    x => x.Country.Equals(country)
                         && x.City.Equals(city)
                         && x.Street.Equals(street));
            }

            if (city != null)
            {
                return Context.Addresses.Where(
                    x => x.Country.Equals(country)
                         && x.City.Equals(city));
            }

            return Context.Addresses.Where(x => x.Country.Equals(country));
        }
    }
}