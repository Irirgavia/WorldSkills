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

        public AddressEntity GetAddressById(int id)
        {
            return Context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AddressEntity> GetAddressesByCountry(string country)
        {
            return Context.Addresses.Where(x => x.Country == country);
        }

        public void CreateAddress(string country, string city, string street, string house, string notes)
        {
            Context.Addresses.Add(new AddressEntity(country, city, street, house, notes));
        }

        public void DeleteAddress(int id)
        {
            var address = this.GetAddressById(id);
            if (address != null)
            {
                Context.Addresses.Remove(address);
            }
        }

        public void UpdateAddress(int id, string country, string city, string street, string house, string notes)
        {
            var address = this.GetAddressById(id);
            if (address != null)
            {
                address.Country = country;
                address.City = city;
                address.Street = street;
                address.House = house;
                address.Notes = notes;
            }
        }
    }
}