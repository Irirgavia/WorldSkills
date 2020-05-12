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

        [Required]
        public ParticipantEntity Participant { get; set; }

        [Required]
        public ResultEntity Result { get; set; }

        [Required]
        public TaskEntity Task { get; private set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}