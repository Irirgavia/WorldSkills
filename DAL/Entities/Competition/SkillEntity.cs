namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SkillEntity : IIdentifier
    {
        public SkillEntity()
        {
        }

        public SkillEntity(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}