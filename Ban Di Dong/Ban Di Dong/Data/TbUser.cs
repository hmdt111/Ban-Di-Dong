using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? Password { get; set; }

    public string? UserPhoneNumber { get; set; }

    public int? RoleId { get; set; }

    public virtual TbRole? Role { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
