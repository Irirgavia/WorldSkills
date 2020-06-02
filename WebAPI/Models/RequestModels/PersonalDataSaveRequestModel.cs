using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    public class PersonalDataSaveRequestModel
    {
        public int userId { get; set; }

        public string surname { get; set; }

        public string name { get; set; }

        public string patronymic { get; set; }

        public string birthday { get; set; }

        public string mail { get; set; }

        public string telephone { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string street { get; set; }

        public string house { get; set; }
    }
}