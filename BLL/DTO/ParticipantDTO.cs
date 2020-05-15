namespace BLL.DTO
{
    using System.Collections.Generic;

    public class ParticipantDTO
    {
        public ParticipantDTO()
        {
            AnswersId = new List<int>();
            StagesId = new List<int>();
        }

        public ParticipantDTO(
            UserDTO user,
            int trainer,
            AddressDTO address,
            ICollection<int> answers,
            ICollection<int> stages)
        {
            User = user;
            Trainer = trainer;
            Address = address;
            AnswersId = answers;
            StagesId = stages;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public int Trainer { get; set; }

        public AddressDTO Address { get; set; }

        public ICollection<int> AnswersId { get; }

        public ICollection<int> StagesId { get; }
    }
}