namespace BLL.DTO
{
    using System.Collections.Generic;

    public class SkillDTO
    {
        public SkillDTO()
        {
        }

        public SkillDTO(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public virtual ICollection<int> Competitions { get; set; }
    }
}