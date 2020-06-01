namespace BLL.DTO.Competition
{
    using System;
    using System.Collections.Generic;

    public class CompetitionDTO
    {
        public CompetitionDTO()
        {
            this.Stages = new List<StageDTO>();
        }

        public CompetitionDTO(
            SkillDTO skill,
            DateTime dateTimeBegin,
            DateTime dateTimeEnd,
            ICollection<StageDTO> stages)
        {
            this.Skill = skill;
            this.DateTimeBegin = dateTimeBegin;
            this.DateTimeEnd = dateTimeEnd;
            this.Stages = stages;
        }

        public int Id { get; private set; }

        public SkillDTO Skill { get; set; }

        public DateTime DateTimeBegin { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public ICollection<StageDTO> Stages { get; set; }
    }
}