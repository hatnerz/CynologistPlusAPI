using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Admin
{
    public int Id { get; set; }

    public int AuthCredentialId { get; set; }

    public virtual AuthCredential AuthCredential { get; set; } = null!;
}
