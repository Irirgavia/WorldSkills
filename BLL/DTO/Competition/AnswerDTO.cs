namespace BLL.DTO.Competition
{
    public class AnswerDTO
    {
        public AnswerDTO()
        {
        }

        public AnswerDTO(
            int accountId, 
            ResultDTO result,
            int taskId,
            string projectLink,
            string notes)
        {
            this.AccountId = accountId;
            this.Result = result;
            this.TaskId = taskId;
            this.ProjectLink = projectLink;
            this.Notes = notes;
        }

        public int Id { get; private set; }

        public int AccountId { get; set; }

        public ResultDTO Result { get; set; }

        public int TaskId { get; set; }

        public string ProjectLink { get; set; }

        public string Notes { get; set; }
    }
}