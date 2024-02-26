using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
}