namespace DAL.Entities.Competition
{
    using System.ComponentModel.DataAnnotations;

    public class StageTypeEntity : IIdentifier
    {
        public StageTypeEntity()
        {
        }

        public StageTypeEntity(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}