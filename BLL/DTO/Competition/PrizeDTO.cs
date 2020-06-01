namespace BLL.DTO.Competition
{
    using System.Collections.Generic;

    public class PrizeDTO
    {
        public PrizeDTO()
        {
        }

        public PrizeDTO(string name)
        {
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}