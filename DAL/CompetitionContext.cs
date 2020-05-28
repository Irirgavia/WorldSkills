namespace DAL
{
    using System.Data.Entity;
    using System.Runtime.CompilerServices;

    using DAL.Entities;

    public class CompetitionContext : DbContext
    {
        static CompetitionContext()
        {
            Database.SetInitializer<CompetitionContext>(new CompetitionContextInitializer());
        }

        public CompetitionContext(string context)
            : base(context)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<AnswerEntity> Answers { get; set; }

        public DbSet<CompetitionEntity> Competitions { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<StageEntity> Stages { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<TrainerEntity> Trainers { get; set; }

        public DbSet<AdministratorEntity> Administrators { get; set; }

        public DbSet<JudgeEntity> Judges { get; set; }


        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Trainer
            modelBuilder.Entity<TrainerEntity>()
                .HasMany(t => t.Participants);
                
            // Competition
            modelBuilder.Entity<CompetitionEntity>()
                .HasMany(c => c.Stages);

            // Stage
            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.Tasks);

            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.Administrators);

            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.Judges);

            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.Participants);

            // Task
            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Answers);

            base.OnModelCreating(modelBuilder);
        }
    }
}