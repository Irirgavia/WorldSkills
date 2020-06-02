namespace BLL.DTO.Competition
{
    public class ResultDTO
    {
        public ResultDTO()
        {
        }

        public ResultDTO(
            PrizeDTO prize,
            float mark,
            string notes)
        {
            this.Mark = mark;
            this.Notes = notes;
            this.Prize = prize;
        }

        public int Id { get; private set; }

        public PrizeDTO Prize { get; set; }

        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}