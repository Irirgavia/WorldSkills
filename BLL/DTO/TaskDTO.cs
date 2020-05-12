namespace BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DAL.Entities;

    public class TaskDTO
    {
        public TaskDTO()
        {
            Answers = new List<AnswerDTO>();
        }

        public TaskDTO(
            StageDTO stage,
            DateTime dateTime,
            TimeSpan time,
            AddressDTO address,
            string description,
            string requirement,
            ICollection<AnswerDTO> answers)
        {
            Stage = stage;
            DateTime = dateTime;
            Time = time;
            Address = address;
            Description = description;
            Requirement = requirement;
            Answers = answers;
        }

        public int Id { get; private set; }

        public StageDTO Stage { get; set; }

        public DateTime DateTime { get; set; }

        public TimeSpan Time { get; set; }

        public AddressDTO Address { get; set; }

        public string Description { get; set; }

        public string Requirement { get; set; }

        public ICollection<AnswerDTO> Answers { get; }
    }
}