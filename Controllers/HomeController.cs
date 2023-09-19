using Microsoft.AspNetCore.Mvc;
namespace test.web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
