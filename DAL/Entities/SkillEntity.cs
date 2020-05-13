namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SkillEntity : IIdentifier
    {
        public SkillEntity()
        {
        }

        public SkillEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}