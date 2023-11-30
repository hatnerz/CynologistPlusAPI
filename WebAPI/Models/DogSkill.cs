using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class DogSkill
{
    public int Id { get; set; }

    public double? Value { get; set; }

    public int? DogId { get; set; }

    public int? SkillId { get; set; }

    [JsonIgnore]
    public virtual Dog? Dog { get; set; }

    [JsonIgnore]
    public virtual Skill? Skill { get; set; }
}
