namespace DAL.Contexts
{
    using System.Data.Entity;

    using DAL.Contexts.Initializers;
    using DAL.Entities.Account;
    using DAL.Entities.Competition;

    public class CompetitionContext : DbContext
    {
        static CompetitionContext()
        {
            Database.SetInitializer<CompetitionContext>(new CompetitionInitializer());
        }

        public CompetitionContext(string context)
            : base(context)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AnswerEntity> Answers { get; set; }

        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<CompetitionEntity> Competitions { get; set; }

        public DbSet<PrizeEntity> Prizes { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<StageEntity> Stages { get; set; }

        public DbSet<StageTypeEntity> StageTypes { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Competition
            modelBuilder.Entity<CompetitionEntity>()
                .HasMany(c => c.StageEntities);

            // Stage
            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.TaskEntities);

            // Task
            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.AnswerEntities);

            base.OnModelCreating(modelBuilder);
        }
    }
}