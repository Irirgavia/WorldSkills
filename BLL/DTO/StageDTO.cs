namespace BLL.DTO
{
    using System.Collections.Generic;

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
            TypeStageDTO typeStageDto,
            ICollection<TaskDTO> tasks,
            ICollection<int> participants,
            ICollection<int> judges,
            ICollection<int> administrators)
        {
            CompetitionId = competition;
            this.TypeStageDto = typeStageDto;
            Tasks = tasks;
            Participants = participants;
            Judges = judges;
            Administrators = administrators;
        }

        public int Id { get; private set; }

        public int CompetitionId { get; set; }

        public TypeStageDTO TypeStageDto { get; set; }

        public ICollection<TaskDTO> Tasks { get; set; }

        public ICollection<int> Participants { get; set; }

        public ICollection<int> Judges { get; set; }

        public ICollection<int> Administrators { get; set; }
    }
}