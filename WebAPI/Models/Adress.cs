using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Adress
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    [JsonIgnore]
    public virtual DogTrainingCenter? IdNavigation { get; set; }
}
