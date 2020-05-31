namespace DAL.Entities.Competition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CompetitionEntity : IIdentifier
    {
        public CompetitionEntity()
        {
            this.StageEntities = new List<StageEntity>();
        }

        public CompetitionEntity(
            int skillEntityId,
            DateTime dateTimeBegin,
            DateTime dateTimeEnd,
            ICollection<StageEntity> stageEntities)
        {
            this.SkillEntityId = skillEntityId;
            this.DateTimeBegin = dateTimeBegin;
            this.DateTimeEnd = dateTimeEnd;
            this.StageEntities = stageEntities;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int SkillEntityId { get; set; }

        [ForeignKey("SkillEntityId")]
        public SkillEntity SkillEntity { get; set; }

        [Required]
        public DateTime DateTimeBegin { get; set; }

        [Required]
        public DateTime DateTimeEnd { get; set; }

        public ICollection<StageEntity> StageEntities { get; set; }
    }
}