using _16_Eylul_Kariyet_net.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_Eylul_Kariyet_net.Controllers;

public class Is_Ilanlari_DetayController : Controller
{
    // GET
    public IActionResult Index(int id)
    {
        Context c = new Context();
        var is_ilanlarim= c.BasvuruLogs.Include(b => b.Jobs).Include(k => k.Kullanici).Where(b=>b.Jobs.JobsID==id).ToList();
        
        return View(is_ilanlarim);
    }
}