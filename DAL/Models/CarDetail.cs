using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class CarDetail
{
    [Key]
    public int CarId { get; set; }

    public string? OwnerAddress { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? LicensePlate { get; set; }

    public long? RcNumber { get; set; }

    public int? InsuranceNumber { get; set; }

    public string? EngineType { get; set; }

    public string? FuelType { get; set; }

    public decimal? Mileage { get; set; }

    public string? Transmission { get; set; }

    public int? FuelCapacity { get; set; }

    public decimal? RentalPricePerDay { get; set; }

    public bool? IsAvailable { get; set; }

    public string? RentalLocation { get; set; }

    public DateTime? AvailableFrom { get; set; }

    public DateTime? AvailableUntil { get; set; }

    public int? MinimumRentalPeriod { get; set; }

    public bool? HomeDeliveryAvailable { get; set; }

    public bool? InsuranceIncluded { get; set; }

    public DateTime? InsuranceExpiryDate { get; set; }

    public string? InsuranceProvider { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? LastServicedDate { get; set; }

    public string? RegistrationState { get; set; }

    public bool? HasAirConditioning { get; set; }

    public bool? HasGPS { get; set; }

    public bool? HasBluetooth { get; set; }

    public bool? HasBackupCamera { get; set; }

    public bool? HasHeatedSeats { get; set; }

    public bool? HasChildSeat { get; set; }

    public string? Color { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public int? SeatingCapacity { get; set; }

    public int? NumberOfDoors { get; set; }

    public bool? IsOutOfStateAllowed { get; set; }

    public decimal? DistanceFromUser { get; set; }

    public decimal? UserRating { get; set; }

    public string? Notes { get; set; }

    public int? NumberOfTrips { get; set; }

    public string? MainImageUrl { get; set; }

    public string? Thumbnails { get; set; }

    public string? Reviews { get; set; }

    public string? Faqs { get; set; }

    public string? Username { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
}
