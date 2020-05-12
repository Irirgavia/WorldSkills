namespace BLL.DTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DAL.Entities;

    public class TrainerDTO
    {
        public TrainerDTO()
        {
            Participants = new List<ParticipantDTO>();
        }

        public TrainerDTO(
            UserDTO user,
            ICollection<ParticipantDTO> participants)
        {
            User = user;
            Participants = participants;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public ICollection<ParticipantDTO> Participants { get; }
    }
}