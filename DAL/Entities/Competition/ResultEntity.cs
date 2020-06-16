namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity()
        {
        }

        public ResultEntity(int prizeEntityId, float mark = 0)
        {
            this.Mark = mark;
        }

        public ResultEntity(
            int prizeEntityId,
            float mark, 
            string notes)
        {
            this.PrizeEntityId = prizeEntityId;
            this.Mark = mark;
            this.Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int PrizeEntityId { get; set; }

        [ForeignKey("PrizeEntityId")]
        public PrizeEntity PrizeEntity { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}