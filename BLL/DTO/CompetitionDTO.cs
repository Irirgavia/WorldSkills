namespace BLL.DTO
{
    using System;
    using System.Collections.Generic;

    using DAL.Entities;

    public class CompetitionDTO
    {
        public CompetitionDTO()
        {
            Stages = new List<StageDTO>();
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

        public SkillDTO Skill { get; private set; }

        public DateTime DateTimeBegin { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public ICollection<StageDTO> Stages { get; private set; }
    }
}