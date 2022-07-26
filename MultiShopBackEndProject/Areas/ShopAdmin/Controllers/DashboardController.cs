using Microsoft.AspNetCore.Mvc;

namespace MultiShopBackEndProject.Areas.ShopAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("ShopAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
