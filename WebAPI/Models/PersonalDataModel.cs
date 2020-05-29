using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PersonalDataModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Birthday { get; set; }

        public string Mail { get; set; }

        public string Telephone { get; set; }

        public int AddressId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string House { get; set; }

        public string Awards { get; set; }
    }
}