namespace BLL.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO()
        {
        }

        public AnswerDTO(
            ParticipantDTO participant, 
            ResultDTO result, 
            TaskDTO task,
            string projectLink,
            string notes)
        {
            Participant = participant;
            Result = result;
            Task = task;
            ProjectLink = projectLink;
            Notes = notes;
        }

        public int Id { get; private set; }

        public ParticipantDTO Participant { get; set; }

        public ResultDTO Result { get; set; }

        public TaskDTO Task { get; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}