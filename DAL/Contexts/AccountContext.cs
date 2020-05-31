namespace DAL.Contexts
{
    using System.Data.Entity;

    using DAL.Contexts.Initializers;
    using DAL.Entities.Account;

    public class AccountContext : DbContext
    {
        static AccountContext()
        {
            Database.SetInitializer<AccountContext>(new AccountInitializer());
        }

        public AccountContext(string context)
            : base(context)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<CredentialsEntity> Credentials { get; set; }

        public DbSet<PersonalDataEntity> PersonalData { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

    }
}