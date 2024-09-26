namespace Ban_Di_Dong.ViewModels
{
    public class CartItem
    {
        public int productId { get; set; }
        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }
        public int quantity { get; set; }

        public double thanhTien => price * quantity;
    }
}
