namespace DAL.Contexts
{
    using System.Data.Entity;

    using DAL.Contexts.Initializers;
    using DAL.Entities.NotificationSystem;

    public class NotificationSystemContext : DbContext
    {
        static NotificationSystemContext()
        {
            Database.SetInitializer<NotificationSystemContext>(new NotificationSystemInitializer());
        }

        public NotificationSystemContext(string context)
            : base(context)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<MailEntity> Mails { get; set; }

        public DbSet<NotificationEntity> Notifications { get; set; }

        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mail
            modelBuilder.Entity<MailEntity>()
                .HasMany(m => m.To);

            base.OnModelCreating(modelBuilder);
        }
    }
}