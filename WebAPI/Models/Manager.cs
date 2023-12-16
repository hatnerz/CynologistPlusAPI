using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [JsonIgnore]
    public int AuthCredentialId { get; set; }

    public int? DogTrainingCenterId { get; set; }

    public virtual AuthCredential? AuthCredential { get; set; } = null!;

    public virtual DogTrainingCenter? DogTrainingCenter { get; set; }
}
