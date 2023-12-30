using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Cynologist
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [JsonIgnore]
    public int? DogTrainingCenterId { get; set; }

    public int AuthCredentialId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]
    public virtual AuthCredential AuthCredential { get; set; } = null!;

    public virtual DogTrainingCenter? DogTrainingCenter { get; set; }

    [JsonIgnore]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
