namespace BLL.Utilities.CsvParser.ClassMap
{
    using System;

    using BLL.DTO.Account;
    using CsvHelper.Configuration;

    public sealed class RegistrationFormMap : ClassMap<RegistrationForm>
    {
        public RegistrationFormMap()
        {
            Map(m => m.PersonalData.Surname).Index(1);
            Map(m => m.PersonalData.Name).Index(2);
            Map(m => m.PersonalData.Patronymic).Index(3);
                       
            Map(m => m.PersonalData.Birthday).Index(4).Constant(DateTime.Today);
            Map(m => m.PersonalData.Photo).Index(5);
            Map(m => m.PersonalData.Mail).Index(6);
            Map(m => m.PersonalData.Telephone).Index(7);

            Map(m => m.PersonalData.Address.Country).Index(8);
            Map(m => m.PersonalData.Address.City).Index(9);
            Map(m => m.PersonalData.Address.Street).Index(10);
            Map(m => m.PersonalData.Address.House).Index(11);

            Map(m => m.Login).Index(13);
            Map(m => m.Password).Index(14);
            Map(m => m.Skill).Index(12);
            Map(m => m.Role).Index(15);
        }
    }
}