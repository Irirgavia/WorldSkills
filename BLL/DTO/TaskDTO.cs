namespace BLL.DTO
{
    using System;
    using System.Collections.Generic;

    public class TaskDTO
    {
        public TaskDTO()
        {
            Answers = new List<AnswerDTO>();
        }

        public TaskDTO(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers)
        {
            StageId = stage;
            DateTime = dateTime;
            Time = time;
            Description = description;
            Requirement = requirement;
            Addresses = addresses;
            Answers = answers;
        }

        public int Id { get; private set; }

        public int StageId { get; set; }

        public DateTime DateTime { get; set; }

        public TimeSpan Time { get; set; }

        public string Description { get; set; }

        public string Requirement { get; set; }

        public ICollection<AddressDTO> Addresses { get; set; }

        public ICollection<AnswerDTO> Answers { get; }
    }
}