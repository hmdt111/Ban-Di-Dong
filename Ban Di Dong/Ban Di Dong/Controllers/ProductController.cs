using Ban_Di_Dong.Data;
using Ban_Di_Dong.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ban_Di_Dong.Controllers
{
    public class ProductController : Controller
    {
        private readonly BanDienThoaiContext db;

        public ProductController(BanDienThoaiContext context) 
        {
            db = context;
        }

        public IActionResult Index(int? loai)
        {
            var products = db.TbProducts.AsQueryable();
            if (loai.HasValue)
            {
                products = products.Where(p => p.CateId == loai.Value);
            }

            var result = products.Select(p => new ProductVM
            {
                productId = p.ProductId,
                productName = p.ProductName,
                price = (double)(p.Price ?? 0),
                productImage = p.Image ?? "",
                description = p.Description ?? "",
                cateName = p.Cate.Name
                

            });
            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var products = db.TbProducts.AsQueryable();
            if (query != null)
            {
                products = products.Where(p => p.ProductName.Contains(query));
            }

            var result = products.Select(p => new ProductVM
            {
                productId = p.ProductId,
                productName = p.ProductName,
                price = (double)(p.Price ?? 0),
                productImage = p.Image ?? "",
                description = p.Description ?? "",
                cateName = p.Cate.Name


            });
            return View(result);
        }


        public IActionResult Detail(int id)
        {
            var data = db.TbProducts
                .Include(p => p.Cate)
                .SingleOrDefault(p => p.ProductId == id);
            if(data == null)
            {
                TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new DetailProductVM
            {
                productId = data.ProductId,
                productName = data.ProductName,
                productImage = data.Image ?? string.Empty,
                price = (double)(data.Price ?? 0),
                description = data.Description ?? string.Empty,
                score = 5,
                cateName = data.Cate.Name,
                stockQuantity = data.StockQuantity ?? 0,

            };
            return View(result);
        }
    }
}
