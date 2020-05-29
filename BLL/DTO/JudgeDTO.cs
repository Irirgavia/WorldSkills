namespace BLL.DTO
{
    using System.Collections.Generic;

    public class JudgeDTO
    {
        public JudgeDTO()
        {
        }

        public JudgeDTO(UserDTO user)
        { 
            User = user;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }
    }
}