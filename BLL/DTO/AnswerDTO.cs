namespace BLL.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO()
        {
        }

        public AnswerDTO(
            int participant, 
            ResultDTO result,
            int taskId,
            string projectLink,
            string notes)
        {
            ParticipantId = participant;
            Result = result;
            TaskId = taskId;
            ProjectLink = projectLink;
            Notes = notes;
        }

        public int Id { get; private set; }

        public int ParticipantId { get; set; }

        public ResultDTO Result { get; set; }

        public int TaskId { get; set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}