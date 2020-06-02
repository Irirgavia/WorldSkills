namespace DAL.Contexts.Initializers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities.Account;

    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            context.Roles.Add(new RoleEntity("administrator"));
            context.Roles.Add(new RoleEntity("judge"));
            context.Roles.Add(new RoleEntity("participant"));

            context.Addresses.Add(new AddressEntity("country", "city", "street", "house", "notes", "apartment"));
            context.SaveChanges();

            context.PersonalData.Add(
                new PersonalDataEntity(
                    "surname",
                    "name",
                    "patronymic",
                    DateTime.Now,
                    "photo",
                    "mail",
                    "telephone",
                    1));
            context.SaveChanges();

            context.Credentials.Add(new CredentialsEntity("login", "password", 1));
            context.SaveChanges();

            context.Accounts.Add(
                new AccountEntity(
                    1,
                    1,
                    false));
            context.SaveChanges();
        }
    }
}