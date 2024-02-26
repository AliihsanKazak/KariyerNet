using _16_Eylul_Kariyet_net.Concrete;
using _16_Eylul_Kariyet_net.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.Controllers;

public class Is_Ilani_YayinlaController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult Index(Jobs j)
    {
        Context c = new Context();
        c.Jobses.Add(j);
        c.SaveChanges();
        
        return View();
    }
}