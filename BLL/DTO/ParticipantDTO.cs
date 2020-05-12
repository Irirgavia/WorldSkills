namespace BLL.DTO
{
    using System.Collections.Generic;

    public class ParticipantDTO
    {
        public ParticipantDTO()
        {
            Answers = new List<AnswerDTO>();
            Stages = new List<StageDTO>();
        }

        public ParticipantDTO(
            UserDTO user,
            TrainerDTO trainer,
            AddressDTO address,
            ICollection<AnswerDTO> answers,
            ICollection<StageDTO> stages)
        {
            User = user;
            Trainer = trainer;
            Address = address;
            Answers = answers;
            Stages = stages;
        }

        public int Id { get; private set; }

        public UserDTO User { get; set; }

        public TrainerDTO Trainer { get; set; }

        public AddressDTO Address { get; set; }

        public ICollection<AnswerDTO> Answers { get; }

        public ICollection<StageDTO> Stages { get; }
    }
}