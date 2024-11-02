using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class ExtraDetailsViewModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        public long AlternatePhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        public string? GovtIdNumber { get; set; } // For Aadhar Number

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
