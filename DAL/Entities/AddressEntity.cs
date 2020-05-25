namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AddressEntity : IIdentifier
    {
        public AddressEntity()
        {
        }

        public AddressEntity(string country, string city, string street, string house, string notes, string apartment)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            Apartment = apartment;
            Notes = notes;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(25)]
        public string Country { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        [Required]
        [MaxLength(25)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public string House { get; set; }

        [MaxLength(10)]
        public string Apartment { get; set; }

        public string Notes { get; set; }
    }
}