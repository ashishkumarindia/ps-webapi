using System;

namespace Demo.Models
{
    public class MedicineDetails
    {
        public int Id { get; set; }
        public string FullName { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public DateTime ExpiryDate { get; init; }
        public string Notes { get; set; }
    }
}
