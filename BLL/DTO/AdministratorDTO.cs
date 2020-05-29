namespace BLL.DTO
{
    using System.Collections.Generic;

    public class AdministratorDTO
    {
        public AdministratorDTO()
        {
        }

        public AdministratorDTO(UserDTO user)
        {
            User = user;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }
    }
}