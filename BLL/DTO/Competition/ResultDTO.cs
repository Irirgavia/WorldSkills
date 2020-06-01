namespace BLL.DTO.Competition
{
    using System.Collections.Generic;

    public class ResultDTO
    {
        public ResultDTO()
        {
            this.Prizes = new List<PrizeDTO>();
        }

        public ResultDTO(
            ICollection<PrizeDTO> prizes,
            float mark,
            string notes)
        {
            this.Mark = mark;
            this.Notes = notes;
            this.Prizes = prizes;
        }

        public int Id { get; private set; }

        public ICollection<PrizeDTO> Prizes { get; set; }

        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}