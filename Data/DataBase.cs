using Bogus;
using Demo.Models;
using System;
using System.Collections.Generic;

namespace Demo.Data
{
    public static class DataBase
    {
        public static List<MedicineDetails> MedicineDetails { get; set; }

        static DataBase()
        {
            _ = ResetData();
        }

        public static IEnumerable<MedicineDetails> ResetData()
        {
            MedicineDetails = new List<MedicineDetails>();
            var id = 1;
            var randomCount = new Randomizer();

            var mockMedicine = new Faker<MedicineDetails>()
                .RuleFor(u => u.Id, f => id++)
                .RuleFor(u => u.Brand, f => f.Company.CompanyName())
                .RuleFor(u => u.ExpiryDate, f => f.Date.Between((DateTime.Now.AddYears(-1)).Date, DateTime.Now.AddYears(2).Date))
                .RuleFor(u => u.FullName, f => f.Person.FullName)
                .RuleFor(u => u.Notes, f => f.Lorem.Sentence())
                .RuleFor(u => u.Quantity, f => f.PickRandom(randomCount.Number(1, 30)))
                .RuleFor(u => u.Price, f => f.Random.Decimal(10, 20));

            MedicineDetails.AddRange(mockMedicine.Generate(10));
            return MedicineDetails;
        }
    }
}
