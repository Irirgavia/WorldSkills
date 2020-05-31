namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity()
        {
            this.PrizeEntities = new List<PrizeEntity>();
        }

        public ResultEntity(float mark = 0)
        {
            this.PrizeEntities = new List<PrizeEntity>();
            this.Mark = mark;
        }

        public ResultEntity(
            ICollection<PrizeEntity> prizeEntities,
            float mark, 
            string notes)
        {
            this.PrizeEntities = prizeEntities;
            this.Mark = mark;
            this.Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        public ICollection<PrizeEntity> PrizeEntities { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}