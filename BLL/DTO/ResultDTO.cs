namespace BLL.DTO
{
    public class ResultDTO
    {
        public ResultDTO()
        {
        }

        public ResultDTO(
            PrizeType prizeType,
            float mark,
            string notes)
        {
            Mark = mark;
            Notes = notes;
        }

        public int Id { get; private set; }

        public PrizeType PrizeType { get; set; }

        public int Answer { get; private set; }

        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}