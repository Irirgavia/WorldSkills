
namespace BLL.DTO.Competition
{
    using System.Collections.Generic;

    using BLL.DTO.Account;

    public class StageDTO
    {
        public StageDTO()
        {
            this.Tasks = new List<TaskDTO>();
            this.AccountIds = new List<int>();
        }

        public StageDTO(
            int competition,
            StageTypeDTO stageTypeDto,
            ICollection<TaskDTO> tasks,
            ICollection<int> accountIds)
        {
            this.CompetitionId = competition;
            this.StageType = stageTypeDto;
            this.Tasks = tasks;
            this.AccountIds = accountIds;
        }

        public int Id { get; private set; }

        public int CompetitionId { get; set; }

        public StageTypeDTO StageType { get; set; }

        public ICollection<TaskDTO> Tasks { get; set; }

        public ICollection<int> AccountIds { get; set; }
    }
}