using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class Proizvoditeli
{
    public int ProizvodId { get; set; }

    public string ProizvodName { get; set; } = null!;

    public virtual ICollection<Tovar> Tovars { get; set; } = new List<Tovar>();
}
