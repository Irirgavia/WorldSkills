namespace BLL.DTO
{
    using System.Collections.Generic;

    public class JudgeDTO
    {
        public JudgeDTO()
        {
            Stages = new List<StageDTO>();
        }

        public JudgeDTO(
            UserDTO user,
            ICollection<StageDTO> stages)
        { 
            User = user;
            Stages = stages;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public ICollection<StageDTO> Stages { get; }
    }
}