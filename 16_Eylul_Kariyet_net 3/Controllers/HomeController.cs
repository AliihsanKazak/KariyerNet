using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _16_Eylul_Kariyet_net.Models;
using _16_Eylul_Kariyet_net.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace _16_Eylul_Kariyet_net.Controllers;

//[AllowAnonymous] controllerın üzerine bırakıldığında bu controller altındaki bütün actionlara erişim izni verilir.
public class HomeController : Controller
{
    Context c = new Context();
    
    
     //Otantike olmadanda sayfaya ulaşmayı sağlar
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpGet]
    public IActionResult Jobs(int id)
    {
        if(id==0)
        {
            var isler = c.Jobses.Include(a => a.Firma).Include(x => x.Sehir.Ulke).Include(k => k.Kategori).Include(c => c.CalismaTuru).Include(s => s.Sehir).ToList();

            return View(isler);
        }
        else
        {
            var isler = c.Jobses.Include(a => a.Firma).Include(x => x.Sehir.Ulke).Include(k => k.Kategori).Include(c => c.CalismaTuru).Include(s => s.Sehir).Where(k => k.KategoriID == id).ToList();

            return View(isler);
        }

     


       
    }
    
    [HttpPost]
    public IActionResult Jobs(string idmiz)
    {
        var isler = c.Jobses.Include(a => a.Firma).Include(x => x.Sehir.Ulke).Include(k => k.Kategori).Include(c => c.CalismaTuru).Include(s => s.Sehir).ToList();




        return View(isler);
    }
    
    [AllowAnonymous]
    public IActionResult Contact()
    {

        return View();
    }


}

