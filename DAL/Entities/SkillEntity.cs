namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SkillEntity : IIdentifier
    {
        public SkillEntity()
        {
            //Competitions = new List<CompetitionEntity>();
        }

        public SkillEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        //public virtual ICollection<CompetitionEntity> Competitions { get; set; }
    }
}