namespace DAL.Contexts.Initializers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities.Account;

    public class AccountInitializer : DropCreateDatabaseAlways<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            context.Roles.Add(new RoleEntity("Administrator"));
            context.Roles.Add(new RoleEntity("Judge"));
            context.Roles.Add(new RoleEntity("Participant"));

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