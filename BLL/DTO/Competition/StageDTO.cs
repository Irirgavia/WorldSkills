
namespace BLL.DTO.Competition
{
    using System.Collections;
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
            IList<TaskDTO> tasks,
            IList<int> accountIds)
        {
            this.CompetitionId = competition;
            this.StageType = stageTypeDto;
            this.Tasks = tasks;
            this.AccountIds = accountIds;
        }

        public int Id { get; private set; }

        public int CompetitionId { get; set; }

        public StageTypeDTO StageType { get; set; }

        public IList<TaskDTO> Tasks { get; set; }
        
        public IList<int> AccountIds { get; set; }
    }
}