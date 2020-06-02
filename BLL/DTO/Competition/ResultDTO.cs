namespace BLL.DTO.Competition
{
    using System.Collections.Generic;

    public class ResultDTO
    {
        public ResultDTO()
        {
        }

        public ResultDTO(
            int prize,
            float mark,
            string notes)
        {
            this.Mark = mark;
            this.Notes = notes;
            this.Prize = prize;
        }

        public int Id { get; private set; }

        public int Prize { get; set; }

        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}