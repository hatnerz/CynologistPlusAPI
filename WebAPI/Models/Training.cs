using System;
using System.Collections.Generic;

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

    public virtual Cynologist? Cynologist { get; set; }

    public virtual Dog? Dog { get; set; }
}
