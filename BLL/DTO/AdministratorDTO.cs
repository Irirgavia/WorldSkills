namespace BLL.DTO
{
    using System.Collections.Generic;

    public class AdministratorDTO
    {
        public AdministratorDTO()
        {
            StagesId = new List<int>();
        }

        public AdministratorDTO(UserDTO user, ICollection<int> stages)
        {
            User = user;
            StagesId = stages;
        }

        public int Id { get; private set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public ICollection<int> StagesId { get; }
    }
}