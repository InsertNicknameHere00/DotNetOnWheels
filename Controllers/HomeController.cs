using Microsoft.AspNetCore.Mvc;

namespace CarManagerAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
