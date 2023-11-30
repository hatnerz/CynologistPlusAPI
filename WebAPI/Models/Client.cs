using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]
    public int AuthCredentialId { get; set; }

    [JsonIgnore]
    public virtual AuthCredential? AuthCredential { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Dog> Dogs { get; set; } = new List<Dog>();
}
