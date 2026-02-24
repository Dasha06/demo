using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class Tovar
{
    public string TovarArticul { get; set; } = null!;

    public int TypeId { get; set; }

    public string TovarIzmer { get; set; } = null!;

    public int TovarPrice { get; set; }

    public int? PostavId { get; set; }

    public int ProizvodId { get; set; }

    public int CategoryId { get; set; }

    public int TovarActiveDiscount { get; set; }

    public int TovarCountOnSklad { get; set; }

    public string? TovarDescription { get; set; }

    public string? TovarImage { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrdersTovar> OrdersTovars { get; set; } = new List<OrdersTovar>();

    public virtual Postavchiki? Postav { get; set; }

    public virtual Proizvoditeli Proizvod { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
