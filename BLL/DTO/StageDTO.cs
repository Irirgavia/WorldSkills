namespace BLL.DTO
{
    using System.Collections.Generic;

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
            int competition,
            TypeStageDTO typeStageDto,
            ICollection<TaskDTO> tasks,
            ICollection<ParticipantDTO> participants,
            ICollection<JudgeDTO> judges,
            ICollection<AdministratorDTO> administrators)
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

        public ICollection<ParticipantDTO> Participants { get; set; }

        public ICollection<JudgeDTO> Judges { get; set; }

        public ICollection<AdministratorDTO> Administrators { get; set; }
    }
}