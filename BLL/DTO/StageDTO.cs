namespace BLL.DTO
{
    using System.Collections.Generic;

    using DAL.Entities;

    public class StageDTO
    {
        public StageDTO()
        {
            Tasks = new List<TaskDTO>();
            Participants = new List<int>();
            Judges = new List<int>();
            Administrators = new List<int>();
        }

        public StageDTO(
            int competition,
            TypeStage typeStage,
            ICollection<TaskDTO> tasks,
            ICollection<int> participants,
            ICollection<int> judges,
            ICollection<int> administrators)
        {
            CompetitionId = competition;
            Tasks = tasks;
            Participants = participants;
            Judges = judges;
            Administrators = administrators;
        }

        public int Id { get; private set; }

        public int CompetitionId { get; private set; }

        public TypeStage TypeStage { get; private set; }

        public ICollection<TaskDTO> Tasks { get; private set; }

        public ICollection<int> Participants { get; private set; }

        public ICollection<int> Judges { get; private set; }

        public ICollection<int> Administrators { get; set; }
    }
}