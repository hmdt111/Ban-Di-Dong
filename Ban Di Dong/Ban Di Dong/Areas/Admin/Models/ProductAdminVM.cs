namespace Ban_Di_Dong.Areas.Admin.Models
{
    public class ProductAdminVM
    {
        public int productId { get; set; }
        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }

        

        public string cateName { get; set; }

        public int stockQuantity { get; set; }

        public int warranty { get; set; }
    }
}
