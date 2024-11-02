using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class RegisterCarViewModel
    {
        [Required(ErrorMessage = "Car Company is required.")]
        [StringLength(50, ErrorMessage = "Car Company name can't exceed 50 characters.")]
        public string? Make { get; set; }

        [Required(ErrorMessage = "Car Name is required.")]
        [StringLength(50, ErrorMessage = "Car Name can't exceed 50 characters.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Owner Address is required.")]
        [StringLength(100, ErrorMessage = "Address can't exceed 100 characters.")]
        public string? OwnerAddress { get; set; }

        [Range(1, 365, ErrorMessage = "Minimum rental period must be between 1 and 365 days.")]
        public int? MinimumRentalPeriod { get; set; }
    }
}
