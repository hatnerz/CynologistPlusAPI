using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public double? MaxValue { get; set; }

    public virtual ICollection<DogSkill> DogSkills { get; set; } = new List<DogSkill>();

    public virtual ICollection<DogSkillsLog> DogSkillsLogs { get; set; } = new List<DogSkillsLog>();
}
