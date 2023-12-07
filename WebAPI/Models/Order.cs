using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderDateTimeOffset { get; set; }

    public decimal? Price { get; set; }

    public string? Currency { get; set; }

    public string? Comment { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? Approved { get; set; }

    public int? DogId { get; set; }

    public int? DogTrainingCenterId { get; set; }

    [JsonIgnore]
    public virtual Dog? Dog { get; set; } = null!;

    [JsonIgnore]
    public virtual DogTrainingCenter? DogTrainingCenter { get; set; }
}
