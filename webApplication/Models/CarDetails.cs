using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApplication.Models
{
    public class CarDetails
    {
        [Key]
        public int CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarCompany { get; set; }
        public string? CarLicensePlate { get; set; }
        public decimal? PricePerDay { get; set; }
        public int? ModelYear { get; set; }
        public string? Address { get; set; }
        /*public long InsuranceNumber { get; set; }
        public long RcNumber { get; set; }
        public int MyProperty { get; set; }
        public decimal Mileage { get; set; }*/
        public string? Status { get; set; }
        public string? Description { get; set; }
        
    }
}
