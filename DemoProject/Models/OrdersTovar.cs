using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class OrdersTovar
{
    public int OrderId { get; set; }

    public string TovarArticul { get; set; } = null!;

    public int OrdTovCount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Tovar TovarArticulNavigation { get; set; } = null!;
}
