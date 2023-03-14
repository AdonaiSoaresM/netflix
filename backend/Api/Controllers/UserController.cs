using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}