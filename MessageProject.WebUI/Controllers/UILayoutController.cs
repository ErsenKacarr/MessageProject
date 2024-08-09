using Microsoft.AspNetCore.Mvc;

namespace MessageProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
