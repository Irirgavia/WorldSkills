namespace BLL.DTO.Competition
{
    public class StageTypeDTO
    {
        public StageTypeDTO()
        {
        }

        public StageTypeDTO(string name)
        {
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}