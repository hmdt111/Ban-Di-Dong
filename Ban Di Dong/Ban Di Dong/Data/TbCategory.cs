using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbCategory
{
    public int CateId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
