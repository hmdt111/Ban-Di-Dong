using Ban_Di_Dong.Data;
using Ban_Di_Dong.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Ban_Di_Dong.Helpers;

namespace Ban_Di_Dong.Controllers
{
    public class CartController : Controller
    {
        private readonly BanDienThoaiContext db;

        public CartController(BanDienThoaiContext context) 
        {
            db = context;
        }
   
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.productId == id);
            if (item != null) 
            { 
                gioHang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
               
            }
            return RedirectToAction("Index");

        }

        public IActionResult AddToCart(int id, int qty = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.productId == id);
            if (item == null)
            {
                var product = db.TbProducts.SingleOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hoá có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    productId = product.ProductId,
                    productName = product.ProductName,
                    price = (double)(product.Price ?? 0),
                    productImage = product.Image ?? string.Empty,
                    quantity = qty,

                };
                gioHang.Add(item);

               
            }
            else
            {
                item.quantity += qty;
            }
            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            return RedirectToAction("Index");
        }
    }
}
