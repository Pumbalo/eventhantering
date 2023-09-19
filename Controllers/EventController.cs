using Microsoft.AspNetCore.Mvc;

namespace test.web.Controllers
{
    [Route("[controller]")]
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}