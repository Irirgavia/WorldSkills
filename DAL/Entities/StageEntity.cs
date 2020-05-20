namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StageEntity : IIdentifier
    {
        public StageEntity()
        {
            Tasks = new List<TaskEntity>();
            Participants = new List<ParticipantEntity>();
            Judges = new List<JudgeEntity>();
            Administrators = new List<AdministratorEntity>();
        }

        public StageEntity(
            CompetitionEntity competition,
            TypeStage typeStage,
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participants,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators)
        {
            Competition = competition;
            Tasks = tasks;
            Participants = participants;
            Judges = judges;
            Administrators = administrators;
        }

        [Key]
        public int Id { get; private set; }

        public int? CompetitionId { get; set; }

        [ForeignKey("CompetitionId")]
        public virtual CompetitionEntity Competition { get; private set; }

        [Required]
        public TypeStage TypeStage { get; private set; }

        public virtual ICollection<TaskEntity> Tasks { get; private set; }

        public virtual ICollection<ParticipantEntity> Participants { get; private set; }

        public virtual ICollection<JudgeEntity> Judges { get; private set; }

        public virtual ICollection<AdministratorEntity> Administrators { get; private set; }
    }
}