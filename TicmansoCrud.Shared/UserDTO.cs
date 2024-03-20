using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;


public partial class UserDTO
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surnames { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long CompanyId { get; set; }

    public long RoleId { get; set; }


}
