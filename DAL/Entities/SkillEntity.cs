namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }
    }
}