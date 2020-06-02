namespace BLL.DTO.Account
{
    public class AddressDTO
    {
        public AddressDTO()
        {
        }

        public AddressDTO(string country, string city, string street, string house, string apartments, string notes)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.House = house;
            this.Notes = notes;
        }

        public int Id { get; private set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Apartments { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{this.Country}, {this.City}, {this.Street}, {this.House}, {this.Apartments}";
        }
    }
}