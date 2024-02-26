using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using _16_Eylul_Kariyet_net.Concrete;
using _16_Eylul_Kariyet_net.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _16_Eylul_Kariyet_net.Controllers
{
    
    public class JobDetailController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public JobDetailController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Index(int id)
        {
            
            
            Context c=new Context();

            var is_detay = c.Jobses.Include(a => a.Firma).Include(x => x.Sehir.Ulke).Include(k => k.Kategori).Include(c => c.CalismaTuru).Include(s => s.Sehir).Where(j => j.JobsID == id).FirstOrDefault();
            
            
            var kisiId = User.Claims.FirstOrDefault().Value;

           var basvuru= c.BasvuruLogs.FirstOrDefault(b => b.JobsID == id && b.KullaniciId == kisiId);

           if (basvuru != null)
           {
               ViewBag.DurumKontrol = true;
           }
           else
           {
               ViewBag.DurumKontrol = false;
           }
            
          

            return View(is_detay);
        }
        
        [HttpPost]
        public async Task<IActionResult> BasvuruYap(int id)
        {
            var kisiId = User.Claims.FirstOrDefault().Value;
            
            Context c = new Context();
            BasvuruLog basvuruLog = new BasvuruLog();
            basvuruLog.JobsID = id;
            basvuruLog.KullaniciId = kisiId;
            c.BasvuruLogs.Add(basvuruLog);
            c.SaveChanges();
            
            //Başvuru Sayısını bir arttırma
            var ilan = c.Jobses.FirstOrDefault(j => j.JobsID==id);

            ilan.BasvuruSayisi += 1;
            c.SaveChanges();
            
            return Redirect($"/JobDetail/Index/{id}");
        }

        
        public IActionResult BasvuruGeriCek(int id)
        {
            var kisiId = User.Claims.FirstOrDefault().Value;
            
            Context c = new Context();
            var basvuru= c.BasvuruLogs.Where(b => b.JobsID == id && b.KullaniciId == kisiId).FirstOrDefault();

            c.BasvuruLogs.Remove(basvuru);
            c.SaveChanges();
            
            var ilan = c.Jobses.FirstOrDefault(j => j.JobsID==id);

            ilan.BasvuruSayisi -= 1;
            c.SaveChanges();
        
            return Redirect($"/JobDetail/Index/{id}");
        }

    }
    
}

