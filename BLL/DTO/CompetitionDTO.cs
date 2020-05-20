namespace BLL.DTO
{
    using System;
    using System.Collections.Generic;

    public class CompetitionDTO
    {
        public CompetitionDTO()
        {
        }

        public CompetitionDTO(
            SkillDTO skill,
            DateTime dateTimeBegin,
            DateTime dateTimeEnd,
            ICollection<StageDTO> stages)
        {
            Skill = skill;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Stages = stages;
        }

        public int Id { get; private set; }

        public int? SkillId { get; set; }

        public virtual SkillDTO Skill { get; set; }

        public DateTime DateTimeBegin { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public virtual ICollection<StageDTO> Stages { get; set; }
    }
}