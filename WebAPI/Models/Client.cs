using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int AuthCredentialId { get; set; }

    public virtual AuthCredential AuthCredential { get; set; } = null!;

    public virtual ICollection<Dog> Dogs { get; set; } = new List<Dog>();
}
