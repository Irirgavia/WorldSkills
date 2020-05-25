namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AnswerEntity : IIdentifier
    {
        public AnswerEntity()
        {
        }

        public AnswerEntity(int participantEntityId, ResultEntity result, int taskEntityId, string projectLink, string notes)
        {
            ParticipantEntityId = participantEntityId;
            Result = result;
            TaskEntityId = taskEntityId;
            ProjectLink = projectLink;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        public int ParticipantEntityId { get; set; }

        [ForeignKey("ParticipantEntityId")]
        public virtual ParticipantEntity Participant { get; set; }

        //public int? ResultId { get; set; }

        [Index(IsUnique = true)]
        //[ForeignKey("ResultId")]
        public virtual ResultEntity Result { get; set; }

        public int TaskEntityId { get; set; }

        //[ForeignKey("TaskEntityId")]
        //public virtual TaskEntity Task { get; set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}