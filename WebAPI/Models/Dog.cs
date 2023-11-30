using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Dog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public int? ClientId { get; set; }

    [JsonIgnore]
    public virtual Client? Client { get; set; }

    [JsonIgnore]
    public virtual ICollection<DogSkill> DogSkills { get; set; } = new List<DogSkill>();

    [JsonIgnore]
    public virtual ICollection<DogSkillsLog> DogSkillsLogs { get; set; } = new List<DogSkillsLog>();

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [JsonIgnore]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
