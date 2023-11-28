using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Dog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<DogSkill> DogSkills { get; set; } = new List<DogSkill>();

    public virtual ICollection<DogSkillsLog> DogSkillsLogs { get; set; } = new List<DogSkillsLog>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
