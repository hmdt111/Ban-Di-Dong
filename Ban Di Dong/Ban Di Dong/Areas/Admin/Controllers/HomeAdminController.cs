using Ban_Di_Dong.Areas.Admin.Models;
using Ban_Di_Dong.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Ban_Di_Dong.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly BanDienThoaiContext db;
        private readonly IWebHostEnvironment _env;
        public HomeAdminController(BanDienThoaiContext context, IWebHostEnvironment env)
        {
            db = context;
            _env = env;
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
        public async Task<IActionResult> ThemSanPhamMoi(TbProduct sanPham, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //if(sanPham.Image != null)
                //{
                //    string uploadsDir = Path.Combine(_env.WebRootPath, "Hinh/Product");
                //    string imageName = sanPham.Image;
                //    string filePath = Path.Combine(uploadsDir, imageName);

                    
                //    using(FileStream stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await file.CopyToAsync(stream);
                //    }
                //    sanPham.Image = imageName;
                    
                //}
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
        [Route("SuaNhaCungCap")]
        [HttpGet]
        public IActionResult SuaNhaCungCap(int maNCC)
        {
            var ncc = db.TbSuppliers.Find(maNCC);
            return View(ncc);
        }

        [Route("SuaNhaCungCap")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhaCungCap(TbSupplier sup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sup).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucNhaCungCap","HomeAdmin");
            }
            return View(sup);
        }
        [Route("XoaNhaCungCap")]
        [HttpGet]

        public IActionResult XoaNhaCungCap(int maNCC)
        {
            TempData["Message"] = "";
            var ncc = db.TbProducts.Where(x => x.SupplierId == maNCC).ToList();
            if (ncc.Count > 0)
            {
                TempData["Message"] = "Không xoá được nhà cung cấp này";
                return RedirectToAction("DanhMucNhaCungCap", "HomeAdmin");
            }
            db.Remove(db.TbCategories.Find(maNCC));
            db.SaveChanges();
            TempData["Message"] = "Xoá loại sản phẩm thành công";
            return RedirectToAction("DanhMucNhaCungCap", "HomeAdmin");
        }

        #endregion

        #region Loai
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

        [Route("SuaLoaiSanPham")]
        [HttpGet]
        public IActionResult SuaLoaiSanPham(int maLoai)
        {
            var Loai = db.TbCategories.Find(maLoai);
            return View(Loai);
        }

        [Route("SuaLoaiSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLoaiSanPham(TbCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
            }
            return View(cat);
        }

        [Route("XoaLoaiSanPham")]
        [HttpGet]

        public IActionResult XoaLoaiSanPham(int maLoai)
        {
            TempData["Message"] = "";
            var Loai = db.TbProducts.Where(x=> x.CateId== maLoai).ToList();
            if (Loai.Count > 0)
            {
                TempData["Message"] = "Không xoá được loại sản phẩm này";
                return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
            }
            db.Remove(db.TbCategories.Find(maLoai));
            db.SaveChanges();
            TempData["Message"] = "Xoá loại sản phẩm thành công";
            return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
        }
        #endregion
    }
}
