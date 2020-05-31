namespace DAL.Entities.Competition
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DAL.Entities.Account;

    public class AnswerEntity : IIdentifier
    {
        public AnswerEntity()
        {
        }

        public AnswerEntity(int accountEntityId, ResultEntity resultEntity, int taskEntityId, string projectLink, string notes)
        {
            this.AccountEntityId = accountEntityId;
            this.ResultEntity = resultEntity;
            this.TaskEntityId = taskEntityId;
            this.ProjectLink = projectLink;
            this.Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int AccountEntityId { get; set; }

        [ForeignKey("AccountEntityId")]
        public AccountEntity AccountEntity { get; set; }

        [Index(IsUnique = true)]
        public ResultEntity ResultEntity { get; set; }

        [Required]
        public int TaskEntityId { get; set; }

        [Required]
        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}