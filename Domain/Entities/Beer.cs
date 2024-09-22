using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Beer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Quantity { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }
}
