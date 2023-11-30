using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class DogTrainingCenter
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual Adress? Adress { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cynologist> Cynologists { get; set; } = new List<Cynologist>();

    [JsonIgnore]
    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
