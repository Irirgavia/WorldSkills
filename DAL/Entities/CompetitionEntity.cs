namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CompetitionEntity : IIdentifier
    {
        public CompetitionEntity()
        {
            Stages = new List<StageEntity>();
        }

        public CompetitionEntity(
            int skillEntityId,
            DateTime dateTimeBegin,
            DateTime dateTimeEnd,
            ICollection<StageEntity> stages)
        {
            SkillEntityId = skillEntityId;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        public int? SkillEntityId { get; set; }

        [ForeignKey("SkillEntityId")]
        public virtual SkillEntity Skill { get; set; }

        [Required]
        public DateTime DateTimeBegin { get; set; }

        [Required]
        public DateTime DateTimeEnd { get; set; }

        public virtual ICollection<StageEntity> Stages { get; set; }
    }
}