using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class CarBasicDetailsViewModel
    {

        public int? RcNumber { get; set; }


        public int? InsuranceNumber { get; set; }

        public string? LicensePlate { get; set; }

        
        public int? Mileage { get; set; }

        
        public int? Year { get; set; }
    }
}
