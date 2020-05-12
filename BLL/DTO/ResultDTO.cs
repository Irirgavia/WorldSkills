namespace BLL.DTO
{
    public class ResultDTO
    {
        public ResultDTO()
        {
        }

        public ResultDTO(
            float mark,
            string notes)
        {
            Mark = mark;
            Notes = notes;
        }

        public int Id { get; private set; }

        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}