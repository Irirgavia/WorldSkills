namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AddressEntity : IIdentifier
    {
        public AddressEntity()
        {
        }

        public AddressEntity(string country, string city, string street, string house, string notes)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string House { get; set; }

        public string Notes { get; set; }
    }
}