using Ban_Di_Dong.Areas.Admin.Models;
using Ban_Di_Dong.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Ban_Di_Dong.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly BanDienThoaiContext db;

        public HomeAdminController(BanDienThoaiContext context)
        {
            db = context;
        }
        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            
            return View();
        }
        #region San Pham
        [Route("danhmucsanpham")]

        public IActionResult DanhMucSanPham()
        {
            var data = db.TbProducts.Select(p => new ProductAdminVM
            {
                productId = p.ProductId,
                productName = p.ProductName,
                price = (double)(p.Price ?? 0),
                productImage = p.Image ?? "",
               
                cateName = p.Cate.Name,
                stockQuantity = p.StockQuantity ?? 0,
                warranty = p.Warranty ?? 0,

                
            });
           
            return View(data);
        }
        

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.CateId = new SelectList(db.TbCategories.ToList(), "CateId", "Name");
            ViewBag.SupplierId = new SelectList(db.TbSuppliers.ToList(), "SupplierId", "SupplierName");
            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TbProduct sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TbProducts.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }
        #endregion

        #region NCC
        [Route("danhmucnhacungcap")]
        public IActionResult DanhMucNhaCungCap()
        {
            var data = db.TbSuppliers.Select(p => new SupplierAdminVM
            {
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName,
                SupplierAddress = p.SupplierAddress,
                SupplierEmail = p.SupplierEmail,
                SupplierPhone = p.SupplierPhone


            });

            return View(data);
        }

        [Route("ThemNhaCungCapMoi")]
        [HttpGet]
        public IActionResult ThemNhaCungCapMoi()
        {
           
            return View();
        }

        [Route("ThemNhaCungCapMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhaCungCapMoi(TbSupplier sup)
        {
            if (ModelState.IsValid)
            {
                db.TbSuppliers.Add(sup);
                db.SaveChanges();
                return RedirectToAction("DanhMucNhaCungCap");
            }
            return View(sup);
        }
        #endregion


        [Route("danhmucloaisanpham")]
        public IActionResult DanhMucLoaiSanPham()
        {
            var data = db.TbCategories.Select(p => new CategoryAdminVM
            {
               CateId = p.CateId,
               Name = p.Name,


            });

            return View(data);
        }

        [Route("ThemLoaiSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemLoaiSanPhamMoi()
        {

            return View();
        }

        [Route("ThemLoaiSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemLoaiSanPhamMoi(TbCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.TbCategories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("DanhMucLoaiSanPham");
            }
            return View(cat);
        }
    }
}
