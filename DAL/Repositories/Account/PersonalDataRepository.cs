namespace DAL.Repositories.Account
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Account;

    public class PersonalDataRepository : GenericRepository<PersonalDataEntity, AccountContext>
    {
        public PersonalDataRepository(AccountContext context)
            : base(context)
        {
        }

        public override IEnumerable<PersonalDataEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(p => p.AddressEntity)
                .AsEnumerable();
        }

        public override IEnumerable<PersonalDataEntity> Get(Func<PersonalDataEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(p => p.AddressEntity)
                .AsEnumerable()
                .Where(predicate);
        }

        public override void Update(PersonalDataEntity item)
        {
            var personalData = this.DbSet
                                   .Include(p => p.AddressEntity)
                                   .AsEnumerable()
                                   .FirstOrDefault(p => p.Id == item.Id);

            personalData.AddressEntity.Apartment = item.AddressEntity.Apartment;
            personalData.AddressEntity.City = item.AddressEntity.City;
            personalData.AddressEntity.Country = item.AddressEntity.Country;
            personalData.AddressEntity.House = item.AddressEntity.House;
            personalData.AddressEntity.Notes = item.AddressEntity.Notes;
            personalData.AddressEntity.Street = item.AddressEntity.Street;

            personalData.Birthday = item.Birthday;
            personalData.Mail = item.Mail;
            personalData.Name = item.Name;
            personalData.Patronymic = item.Patronymic;
            personalData.Surname = item.Surname;
            personalData.Photo = item.Photo;
            personalData.Telephone = item.Telephone;
        }
    }
}