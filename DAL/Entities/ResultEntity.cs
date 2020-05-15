namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity(float mark = 0)
        {
            PrizeType = PrizeType.NonAwardWinning;
            Mark = mark;
        }

        public ResultEntity(
            PrizeType prizeType,
            float mark, 
            string notes)
        {
            PrizeType = prizeType;
            Mark = mark;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public virtual AnswerEntity Answer { get; private set; }

        [Required]
        public PrizeType PrizeType { get; set; }

        [Required]
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}