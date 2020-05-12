namespace BLL.DTO
{
    using System.Collections.Generic;

    using DAL.Entities;

    public class StageDTO
    {
        public StageDTO()
        {
            Tasks = new List<TaskDTO>();
            Participants = new List<ParticipantDTO>();
            Judges = new List<JudgeDTO>();
            Administrators = new List<AdministratorDTO>();
        }

        public StageDTO(
            CompetitionDTO competition,
            TypeStage typeStage,
            ICollection<TaskDTO> tasks,
            ICollection<ParticipantDTO> participants,
            ICollection<JudgeDTO> judges,
            ICollection<AdministratorDTO> administrators)
        {
            Competition = competition;
            Tasks = tasks;
            Participants = participants;
            Judges = judges;
            Administrators = administrators;
        }

        public int Id { get; private set; }

        public CompetitionDTO Competition { get; }

        public TypeStage TypeStage { get; }

        public ICollection<TaskDTO> Tasks { get; }

        public ICollection<ParticipantDTO> Participants { get; }

        public ICollection<JudgeDTO> Judges { get; }

        public ICollection<AdministratorDTO> Administrators { get; set; }
    }
}