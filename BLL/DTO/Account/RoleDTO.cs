namespace BLL.DTO.Account
{
    public class RoleDTO
    {
        public RoleDTO()
        {
        }

        public RoleDTO(string name)
        {
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}