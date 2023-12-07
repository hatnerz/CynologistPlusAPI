using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Training
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? TrainingType { get; set; }

    public int? DogId { get; set; }

    public int? CynologistId { get; set; }

    public string? Comment { get; set; }

    [JsonIgnore]
    public virtual Cynologist? Cynologist { get; set; }

    [JsonIgnore]
    public virtual Dog? Dog { get; set; }
}
