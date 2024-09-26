using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
