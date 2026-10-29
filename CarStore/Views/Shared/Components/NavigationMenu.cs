using DatabaseService;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Views.Shared.Components
{
    public class NavigationMenu: ViewComponent
    {
        ApplicationContext db;
        public NavigationMenu(ApplicationContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(db.Categories);
        }
    }
}
