using Ban_Di_Dong.Helpers;
using Ban_Di_Dong.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ban_Di_Dong.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
            return View("CartPanel", new CartModel
            {
                quantity = cart.Sum(p => p.quantity),
                total = cart.Sum(p => p.thanhTien)
            });
        }
    }
}
