using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["message"] = "Aceasta este o aplicatie care te ajuta sa fii organizat! ";
            return View();
        }
    }
}