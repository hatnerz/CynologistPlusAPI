using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class DogSkill
{
    public int Id { get; set; }

    public double? Value { get; set; }

    public int? DogId { get; set; }

    public int? SkillId { get; set; }

    public virtual Dog? Dog { get; set; }

    public virtual Skill? Skill { get; set; }
}
