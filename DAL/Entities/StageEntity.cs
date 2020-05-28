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
            int competitionEntityId,
            TypeStageEntity typeStageEntity,
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participants,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators)
        {
            CompetitionEntityId = competitionEntityId;
            TypeStageEntity = typeStageEntity;
            Tasks = tasks;
            Participants = participants;
            Judges = judges;
            Administrators = administrators;
        }

        [Key]
        public int Id { get; private set; }

        public int? CompetitionEntityId { get; set; }

        [Required]
        public TypeStageEntity TypeStageEntity { get; private set; }

        public virtual ICollection<TaskEntity> Tasks { get; private set; }

        public virtual ICollection<ParticipantEntity> Participants { get; private set; }

        public virtual ICollection<JudgeEntity> Judges { get; private set; }

        public virtual ICollection<AdministratorEntity> Administrators { get; private set; }
    }
}