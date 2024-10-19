using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApplication.Models
{
    public class CarDetails
    {
        [Key]
        // Primary Key
        public int CarId { get; set; }

        // Basic Car Information
        public string? Make { get; set; }           // e.g., Toyota, Ford
        public string? Model { get; set; }          // e.g., Corolla, Mustang
        public int? Year { get; set; }              // e.g., 2020
        public string? LicensePlate { get; set; }   // e.g., ABC1234
        public string? Trim { get; set; }           // e.g., SE, LE, Sport
        public long RcNumber { get; set; }
        public int InsuranceNumber { get; set; }

        // Technical Specifications
        public string? EngineType { get; set; }     // e.g., V6, Electric
        public string? FuelType { get; set; }       // e.g., Gasoline, Diesel, Electric
        public decimal? Mileage { get; set; }       // e.g., 50Kmph
        public string? Transmission { get; set; }   // e.g., Manual, Automatic
        public int? HorsePower { get; set; }        // e.g., 300 hp
        public int? Torque { get; set; }            // e.g., 350 Nm
        public string? Drivetrain { get; set; }     // e.g., FWD, AWD, RWD
        public decimal? FuelCapacity { get; set; }  // e.g., 55.5 liters
        public decimal? FuelEfficiency { get; set; } // e.g., 25.0 mpg

        // Rental Information
        public decimal? RentalPricePerDay { get; set; }  // e.g., $50 per day
        public bool? IsAvailable { get; set; }           // true/false if the car is available for rent
        public string? RentalLocation { get; set; }      // e.g., City or neighborhood where car is available
        public DateTime? AvailableFrom { get; set; }     // Start date for availability
        public DateTime? AvailableUntil { get; set; }    // End date for availability
        public int? MinimumRentalPeriod { get; set; }    // Minimum number of rental days
        public bool? HomeDeliveryAvailable { get; set; } // true/false if home delivery is available

        // Insurance Information
        public bool? InsuranceIncluded { get; set; }     // true/false if insurance is included
        public DateTime? InsuranceExpiryDate { get; set; } // Expiry date of insurance
        public string? InsuranceProvider { get; set; }   // Insurance company

        // Owner Information
        public string? OwnerName { get; set; }           // Owner's name
        public string? OwnerPhoneNumber { get; set; }    // Owner's contact number
        public string? OwnerEmail { get; set; }          // Owner's contact email
        public string? OwnerAddress { get; set; }        // Owner's address

        // Registration and Documentation Information
        public DateTime? RegistrationDate { get; set; }  // Date of registration
        public DateTime? LastServicedDate { get; set; }  // Last service date
        public string? RegistrationState { get; set; }   // State or region where the car is registered

        // Car Features
        public bool? HasAirConditioning { get; set; }    // true/false
        public bool? HasGPS { get; set; }                // true/false
        public bool? HasBluetooth { get; set; }          // true/false
        public bool? HasBackupCamera { get; set; }       // true/false
        public bool? HasHeatedSeats { get; set; }        // true/false
        public bool? IsPetFriendly { get; set; }         // true/false
        public bool? HasChildSeat { get; set; }          // true/false (child seat available)

        // Exterior Specifications
        public string? Color { get; set; }               // e.g., Red, Black
        public decimal? Length { get; set; }             // e.g., 4.5 meters
        public decimal? Width { get; set; }              // e.g., 1.8 meters
        public decimal? Height { get; set; }             // e.g., 1.6 meters
        public int? SeatingCapacity { get; set; }        // e.g., 5 seats
        public int? NumberOfDoors { get; set; }          // e.g., 4 doors

        // Rental Conditions
        public bool? IsSmokingAllowed { get; set; }      // true/false if smoking is allowed
        public bool? IsOutOfStateAllowed { get; set; }   // true/false if the car can be driven out of state
        public bool? HasMileageLimit { get; set; }       // true/false if there is a mileage limit
        public decimal? MileageLimit { get; set; }       // e.g., 200 miles per day
        public decimal? ExtraMileageFee { get; set; }    // e.g., $0.50 per extra mile

        // Additional Rental Details
        public decimal? DistanceFromUser { get; set; }   // Distance in kilometers/miles from the user
        public decimal? UserRating { get; set; }         // User rating out of 5.0

        // Additional Notes
        public string? Notes { get; set; }

    }
}
