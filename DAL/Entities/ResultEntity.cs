namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity(float mark = 0)
        {
            Mark = mark;
        }

        public ResultEntity(
            float mark, 
            string notes)
        {
            Mark = mark;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        public AnswerEntity Answer { get; private set; }

        [Required]
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}