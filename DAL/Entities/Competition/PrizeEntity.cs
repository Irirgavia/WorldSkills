namespace DAL.Entities.Competition
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PrizeEntity : IIdentifier
    {
        public PrizeEntity()
        {
        }

        public PrizeEntity(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}