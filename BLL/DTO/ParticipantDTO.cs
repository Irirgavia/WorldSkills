namespace BLL.DTO
{
    using System.Collections.Generic;

    public class ParticipantDTO
    {
        public ParticipantDTO()
        {
        }

        public ParticipantDTO(
            UserDTO user,
            int? trainer,
            AddressDTO address)
        {
            User = user;
            Trainer = trainer;
            Address = address;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public int? Trainer { get; set; }

        public AddressDTO Address { get; set; }
    }
}