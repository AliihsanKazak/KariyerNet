using _16_Eylul_Kariyet_net.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_Eylul_Kariyet_net.Controllers;

public class Is_IlanlariController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        var kisiId = User.Claims.FirstOrDefault().Value;
        
        Context c = new Context();
     
       var is_ilanlarim= c.Jobses.Include(f => f.Firma).Where(j => j.FirmaId == kisiId).ToList();
        
        return View(is_ilanlarim);
    }
}