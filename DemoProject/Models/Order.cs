using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderCreateDate { get; set; }

    public DateOnly OrderDeliverDate { get; set; }

    public int PvId { get; set; }

    public int UserId { get; set; }

    public int OrderCode { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual ICollection<OrdersTovar> OrdersTovars { get; set; } = new List<OrdersTovar>();

    public virtual PunktVydach Pv { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
