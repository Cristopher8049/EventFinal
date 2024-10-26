using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePic { get; set; }

    public string? Socials { get; set; }

    public int? RoleId { get; set; }

    public virtual Rol? Role { get; set; }

   
}
