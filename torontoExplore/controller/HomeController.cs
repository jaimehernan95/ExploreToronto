using Microsoft.AspNetCore.Mvc;

namespace torontoExplore.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
