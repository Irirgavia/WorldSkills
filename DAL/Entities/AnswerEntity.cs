namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AnswerEntity : IIdentifier
    {
        public AnswerEntity()
        {
        }

        public AnswerEntity(ParticipantEntity participant, ResultEntity result, TaskEntity task, string projectLink, string notes)
        {
            Participant = participant;
            Result = result;
            Task = task;
            ProjectLink = projectLink;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        public int ParticipantId { get; set; }

        [ForeignKey("ParticipantId")]
        public virtual ParticipantEntity Participant { get; set; }

        //public int? ResultId { get; set; }

        [Index(IsUnique = true)]
        //[ForeignKey("ResultId")]
        public virtual ResultEntity Result { get; set; }

        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual TaskEntity Task { get; set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}