namespace BLL.DTO.Competition
{
    public class SkillDTO
    {
        public SkillDTO()
        {
        }

        public SkillDTO(string name)
        {
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}