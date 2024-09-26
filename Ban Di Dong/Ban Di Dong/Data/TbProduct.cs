using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public int? Warranty { get; set; }

    public string? Description { get; set; }

    public int? CateId { get; set; }

    public int? SupplierId { get; set; }

    public virtual TbCategory? Cate { get; set; }

    public virtual TbSupplier? Supplier { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
