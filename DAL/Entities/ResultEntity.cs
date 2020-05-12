namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ResultEntity : IIdentifier
    {
        public ResultEntity()
        {
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
        public float Mark { get; set; }

        public string Notes { get; set; }
    }
}