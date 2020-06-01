namespace DAL.Contexts
{
    using System.Data.Entity;

    using DAL.Contexts.Initializers;
    using DAL.Entities.NotificationSystem;

    public class SystemContext : DbContext
    {
        static SystemContext()
        {
            Database.SetInitializer<SystemContext>(new SystemInitializer());
        }

        public SystemContext(string context)
            : base(context)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<MailEntity> Mails { get; set; }

        public DbSet<NotificationEntity> Notifications { get; set; }

        public DbSet<NewsEntity> News { get; set; }


        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}