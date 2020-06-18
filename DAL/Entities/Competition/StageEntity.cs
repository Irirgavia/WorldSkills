namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StageEntity : IIdentifier
    {
        public StageEntity()
        {
            this.TaskEntities = new List<TaskEntity>();
            this.AccountIds = new List<int>();
        }

        public StageEntity(
            int competitionEntityId,
            int stageTypeEntityId,
            IList<TaskEntity> taskEntities,
            IList<int> accountIds)
        {
            this.CompetitionEntityId = competitionEntityId;
            this.StageTypeEntityId = stageTypeEntityId;
            this.TaskEntities = taskEntities;
            this.AccountIds = accountIds;
            this.AccountIds = accountIds;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int CompetitionEntityId { get; set; }

        [Required]
        public int StageTypeEntityId { get; set; }

        [ForeignKey("StageTypeEntityId")]
        public StageTypeEntity StageTypeEntity { get; set; }

        public IList<TaskEntity> TaskEntities { get; set; }

        public IList<int> AccountIds { get; set; }
    }
}