using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class RentalDetail
{
    [Key]
    public int RentalId { get; set; }

    public string? Location { get; set; }

    public DateTime FromDateTime { get; set; }

    public DateTime ToDateTime { get; set; }

    public double? RentalDuration { get; set; }

    public int? UserId { get; set; }

    public int? CarId { get; set; }

    public virtual CarDetail? Car { get; set; }

    public virtual User? User { get; set; }
}
