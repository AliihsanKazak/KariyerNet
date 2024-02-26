using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.Controllers;

[AllowAnonymous]
public class SelectionController : Controller
{
   
    public IActionResult Index()
    {
        return View();
    }
}