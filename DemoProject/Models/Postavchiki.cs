using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class Postavchiki
{
    public int PostavId { get; set; }

    public string PostavName { get; set; } = null!;

    public virtual ICollection<Tovar> Tovars { get; set; } = new List<Tovar>();
}
