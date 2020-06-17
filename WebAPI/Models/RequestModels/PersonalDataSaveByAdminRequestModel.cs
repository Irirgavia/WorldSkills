using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class PersonalDataSaveByAdminRequestModel
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Birthday { get; set; }

        public string Mail { get; set; }

        public string Telephone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string House { get; set; }

        public string Apartment { get; set; }
    }
}