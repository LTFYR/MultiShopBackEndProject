using Microsoft.AspNetCore.Mvc;

namespace MultiShopBackEndProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
