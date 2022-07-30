using Microsoft.AspNetCore.Mvc;

namespace MultiShopBackEndProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
