using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public long? PhoneNumber { get; set; }

    public long? AlternatePhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
}
