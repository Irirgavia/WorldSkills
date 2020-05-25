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
            // User
            /*modelBuilder.Entity<UserEntity>()
                .HasOptional(u => u.AdministratorEntity)
                .WithRequired(p => p.User);
            
            modelBuilder.Entity<UserEntity>()
                .HasOptional(u => u.ParticipantEntity)
                .WithRequired(p => p.UserEntity);
                
            modelBuilder.Entity<UserEntity>()
                .HasOptional(u => u.JudgeEntity)
                .WithRequired(p => p.User);
            
            modelBuilder.Entity<UserEntity>()
                .HasOptional(u => u.TrainerEntity)
                .WithRequired(p => p.User);
                */
            // Trainer
            modelBuilder.Entity<TrainerEntity>()
                .HasMany(t => t.Participants)
                .WithOptional(p => p.Trainer); 
                
            // Participant
            modelBuilder.Entity<ParticipantEntity>()
                .HasMany(p => p.Stages)
                .WithMany(s => s.Participants);
            
            modelBuilder.Entity<ParticipantEntity>()
                .HasMany(p => p.Answers)
                .WithRequired(a => a.Participant);
                
            // Admin
            modelBuilder.Entity<AdministratorEntity>()
                .HasMany(a => a.Stages)
                .WithMany(s => s.Administrators);

            // Judge
            modelBuilder.Entity<JudgeEntity>()
                .HasMany(j => j.Stages)
                .WithMany(s => s.Judges);
            
            // Skill
            /*modelBuilder.Entity<SkillEntity>()
                .HasMany(s => s.Competitions)
                .WithRequired(c => c.Skill);*/
                
            // Competition
            modelBuilder.Entity<CompetitionEntity>()
                .HasMany(c => c.Stages);

            // Stage
            modelBuilder.Entity<StageEntity>().HasMany(s => s.Tasks);
                //.WithRequired(t => t.Stage);

            // Task
            modelBuilder.Entity<TaskEntity>().HasMany(t => t.Answers);
                //.WithRequired(a => a.Task);
            
            // Result
            /*modelBuilder.Entity<ResultEntity>()
                .HasRequired(r => r.Answer)
                .WithRequiredPrincipal(a => a.Result);*/
                
            base.OnModelCreating(modelBuilder);
        }
    }
}