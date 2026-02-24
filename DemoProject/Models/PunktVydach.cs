using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class PunktVydach
{
    public int PvId { get; set; }

    public string PvAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
