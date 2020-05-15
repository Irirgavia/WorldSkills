namespace BLL.DTO
{
    using System.Collections.Generic;

    public class JudgeDTO
    {
        public JudgeDTO()
        {
            StagesId = new List<int>();
        }

        public JudgeDTO(
            UserDTO user,
            ICollection<int> stages)
        { 
            User = user;
            StagesId = stages;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public ICollection<int> StagesId { get; }
    }
}