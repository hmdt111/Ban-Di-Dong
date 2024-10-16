using System.ComponentModel.DataAnnotations;

namespace Ban_Di_Dong.Areas.Admin.Models
{
    public class SupplierAdminVM
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierPhone { get; set; }
       
        public string SupplierAddress { get; set; }
    }
}
