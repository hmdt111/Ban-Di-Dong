using System;
using System.Collections.Generic;

namespace Ban_Di_Dong.Data;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public int? CustomerId { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual TbUser? Customer { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
