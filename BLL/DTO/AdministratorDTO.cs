namespace BLL.DTO
{
    using System.Collections.Generic;

    public class AdministratorDTO
    {
        public AdministratorDTO()
        {
            Stages = new List<StageDTO>();
        }

        public AdministratorDTO(UserDTO user, ICollection<StageDTO> stages)
        {
            User = user;
            Stages = stages;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public ICollection<StageDTO> Stages { get; }
    }
}