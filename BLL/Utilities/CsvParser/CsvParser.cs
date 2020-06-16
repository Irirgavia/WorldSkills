namespace BLL.Utilities.CsvParser
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.Utilities.CsvParser.ClassMap;

    using CsvHelper;

    public static class CsvParser
    {
        public static IEnumerable<RegistrationForm> GetRegistrationFormsByCsvFile(string pathToFileCsv)
        { 
            List<RegistrationForm> registrationForms;

            using (var reader = new StreamReader(pathToFileCsv))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<RegistrationFormMap>();
                    registrationForms = csv.GetRecords<RegistrationForm>().ToList();
                }

            return registrationForms;
        }
    }
}