using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class DogSkillOut
{
    public int Id { get; set; }

    public double? Value { get; set; }

    public int? DogId { get; set; }

    public virtual Skill? Skill { get; set; }
}
