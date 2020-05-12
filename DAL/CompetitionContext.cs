namespace DAL
{
    using System.Data.Entity;

    using DAL.Entities;

    public class CompetitionContext : DbContext
    {
        static CompetitionContext()
        {
            Database.SetInitializer<CompetitionContext>(new CompetitionContextInitializer());
        }

        public CompetitionContext()
            : base("CompetitionContext")
        {
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
            modelBuilder.Entity<TrainerEntity>()
                .HasMany(t => t.Participants);


            modelBuilder.Entity<ParticipantEntity>()
                .HasMany(p => p.Stages)
                .WithMany(s => s.Participants);

            modelBuilder.Entity<ParticipantEntity>()
                .HasMany(p => p.Answers);

            modelBuilder.Entity<AdministratorEntity>()
                .HasMany(a => a.Stages)
                .WithMany(s => s.Administrators);

            modelBuilder.Entity<JudgeEntity>()
                .HasMany(j => j.Stages)
                .WithMany(s => s.Judges);

            modelBuilder.Entity<CompetitionEntity>()
                .HasMany(c => c.Stages);

            modelBuilder.Entity<StageEntity>()
                .HasMany(s => s.Tasks);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Answers);

            base.OnModelCreating(modelBuilder);
        }
    }
}