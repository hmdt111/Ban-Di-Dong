using Microsoft.Identity.Client;

namespace Ban_Di_Dong.ViewModels
{
    public class ProductVM
    {
        public int productId { get; set; }
        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public string cateName { get; set; }
    }

    public class DetailProductVM
    {
        public int productId { get; set; }
        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public string cateName { get; set; }

        public int stockQuantity { get; set; }

        public int score { get; set; }
    }
}
