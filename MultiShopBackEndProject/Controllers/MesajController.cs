using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    //[Authorize(Roles ="Member")]    
    public class MesajController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MesajController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid) return View();
                AppUser user = await _userManager.FindByEmailAsync(contact.Email);
                if (user != null)
                {
                    Contact ctc = new Contact
                    {
                        Email = contact.Email,
                        Name = contact.Name,
                        Message = contact.Message,
                        Subject = contact.Subject
                    };
                    await _context.Contacts.AddAsync(ctc);
                    await _context.SaveChangesAsync();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Name", "You have to login");
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
