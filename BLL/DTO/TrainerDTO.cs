namespace BLL.DTO
{
    using System.Collections.Generic;

    public class TrainerDTO
    {
        public TrainerDTO()
        {
            ParticipantsId = new List<int>();
        }

        public TrainerDTO(
            UserDTO user,
            ICollection<int> participants)
        {
            User = user;
            ParticipantsId = participants;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public ICollection<int> ParticipantsId { get; set; }
    }
}