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
            string projectLink,
            string notes)
        {
            Participant = participant;
            Result = result;
            ProjectLink = projectLink;
            Notes = notes;
        }

        public int Id { get; private set; }

        public ParticipantDTO Participant { get; set; }

        public ResultDTO Result { get; set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}