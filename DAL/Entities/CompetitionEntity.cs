namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CompetitionEntity : IIdentifier
    {
        public CompetitionEntity()
        {
            Stages = new List<StageEntity>();
        }

        public CompetitionEntity(
            SkillEntity skill,
            DateTime dateTimeBegin,
            DateTime dateTimeEnd,
            ICollection<StageEntity> stages)
        {
            Skill = skill;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Stages = stages;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public virtual SkillEntity Skill { get; private set; }

        [Required]
        public DateTime DateTimeBegin { get; set; }

        [Required]
        public DateTime DateTimeEnd { get; set; }

        [Required]
        public virtual ICollection<StageEntity> Stages { get; private set; }
    }
}