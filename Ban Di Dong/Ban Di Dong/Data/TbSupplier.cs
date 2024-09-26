using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbSupplier
{
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? SupplierEmail { get; set; }

    public string? SupplierPhone { get; set; }

    public string? SupplierAddress { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
