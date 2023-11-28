using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class AuthCredential
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Cynologist> Cynologists { get; set; } = new List<Cynologist>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
}
