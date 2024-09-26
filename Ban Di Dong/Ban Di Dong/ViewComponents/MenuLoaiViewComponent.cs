using Ban_Di_Dong.Data;
using Ban_Di_Dong.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ban_Di_Dong.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly BanDienThoaiContext db;

        public MenuLoaiViewComponent(BanDienThoaiContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.TbCategories.Select(lo => new MenuLoaiVM
            {
                CateID = lo.CateId, 
                Name =  lo.Name , 
                soLuong = lo.TbProducts.Count
            }).OrderBy(p => p.Name);
            return View(data);
        }
    }
}
