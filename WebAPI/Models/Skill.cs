using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public double? MaxValue { get; set; }

    public string? MeasureUnit { get; set; }

    [JsonIgnore]
    public virtual ICollection<DogSkill> DogSkills { get; set; } = new List<DogSkill>();

    [JsonIgnore]
    public virtual ICollection<DogSkillsLog> DogSkillsLogs { get; set; } = new List<DogSkillsLog>();
}
