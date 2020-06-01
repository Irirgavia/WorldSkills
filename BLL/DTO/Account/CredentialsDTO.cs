namespace BLL.DTO.Account
{
    using BLL.Utilities;

    public class CredentialsDTO
    {
        public CredentialsDTO()
        {
        }

        public CredentialsDTO(string login, string password, RoleDTO role)
        {
            this.Login = login;
            this.Password = PasswordHasher.Hash(password);
        }

        public int Id { get; private set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public RoleDTO Role { get; set; }
    }
}