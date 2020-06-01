namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity()
        {
            this.PrizeEntityIds = new List<int>();
        }

        public ResultEntity(float mark = 0)
        {
            this.PrizeEntityIds = new List<int>();
            this.Mark = mark;
        }

        public ResultEntity(
            ICollection<int> prizeEntityIds,
            float mark, 
            string notes)
        {
            this.PrizeEntityIds = prizeEntityIds;
            this.Mark = mark;
            this.Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        public ICollection<int> PrizeEntityIds { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}