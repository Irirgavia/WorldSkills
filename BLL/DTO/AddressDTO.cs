namespace BLL.DTO
{
    public class AddressDTO
    {
        public AddressDTO(string country, string city, string street, string house, string notes)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            Notes = notes;
        }

        public int Id { get; private set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{Country}, {City}, {Street}, {House}";
        }
    }
}