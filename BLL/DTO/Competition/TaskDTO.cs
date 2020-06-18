namespace BLL.DTO.Competition
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;

    public class TaskDTO
    {
        public TaskDTO()
        {
            this.Answers = new List<AnswerDTO>();
            this.Addresses = new List<AddressDTO>();
        }

        public TaskDTO(
            int stage,
            DateTime dateTimeBegin,
            TimeSpan durationTime,
            string description,
            string requirement,
            IList<AddressDTO> addresses,
            IList<AnswerDTO> answers)
        {
            this.StageId = stage;
            this.DateTimeBegin = dateTimeBegin;
            this.DurationTime = durationTime;
            this.Description = description;
            this.Requirement = requirement;
            this.Addresses = addresses;
            this.Answers = answers;
        }

        public int Id { get; private set; }

        public int StageId { get; set; }

        public DateTime DateTimeBegin { get; set; }

        public TimeSpan DurationTime { get; set; }

        public string Description { get; set; }

        public string Requirement { get; set; }

        public IList<AddressDTO> Addresses { get; set; }

        public IList<AnswerDTO> Answers { get; }
    }
}