using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class DogTrainingCenter
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual Adress? Adress { get; set; }

    public virtual ICollection<Cynologist> Cynologists { get; set; } = new List<Cynologist>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
