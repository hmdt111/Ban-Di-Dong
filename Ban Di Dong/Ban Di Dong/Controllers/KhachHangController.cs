using AutoMapper;
using Ban_Di_Dong.Data;
using Ban_Di_Dong.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace Ban_Di_Dong.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly BanDienThoaiContext db;
        private readonly IMapper _mapper;

        public KhachHangController(BanDienThoaiContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<TbUser>(model);
                    db.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        #region Login
        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model,string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid) 
            { 
                var user = db.TbUsers.SingleOrDefault(u => u.UserName == model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("Lỗi", "Sai thông tin đăng nhập.");
                }
                else
                {
                    if (user.Password != model.Password)
                    {
                        ModelState.AddModelError("Lỗi", "Sai thông tin đăng nhập.");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,user.UserEmail),
                            new Claim(ClaimTypes.Name,user.HoTen),
                            new Claim("UserName",user.UserName),
                            new Claim(ClaimTypes.Role,"Customer")
                        };

                        var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return Redirect("/");
                        }

                    }
                }
            }
            return View();
        }
        #endregion
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
