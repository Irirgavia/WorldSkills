namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DAL.Entities.Account;

    public class StageEntity : IIdentifier
    {
        public StageEntity()
        {
            this.TaskEntities = new List<TaskEntity>();
            this.AccountEntities = new List<AccountEntity>();
        }

        public StageEntity(
            int competitionEntityId,
            StageTypeEntity stageTypeEntity,
            ICollection<TaskEntity> taskEntities,
            ICollection<AccountEntity> accountEntities)
        {
            this.CompetitionEntityId = competitionEntityId;
            this.StageTypeEntity = stageTypeEntity;
            this.TaskEntities = taskEntities;
            this.AccountEntities = accountEntities;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int CompetitionEntityId { get; set; }

        [Required]
        public StageTypeEntity StageTypeEntity { get; set; }

        public ICollection<TaskEntity> TaskEntities { get; set; }

        public ICollection<AccountEntity> AccountEntities { get; set; }
    }
}