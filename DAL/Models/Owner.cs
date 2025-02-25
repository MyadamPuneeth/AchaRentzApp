﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class Owner
{
    [Key]
    public int OwnerId { get; set; }

    public int? UserId { get; set; }

    public int? CarId { get; set; }

    public virtual CarDetail? Car { get; set; }

    public virtual User? User { get; set; }
}
