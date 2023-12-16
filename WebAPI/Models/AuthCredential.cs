using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class AuthCredential
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? PasswordHash { get; set; }

    [JsonIgnore]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [JsonIgnore]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [JsonIgnore]
    public virtual ICollection<Cynologist> Cynologists { get; set; } = new List<Cynologist>();

    [JsonIgnore]
    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
}
