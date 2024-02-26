using System.Dynamic;
using _16_Eylul_Kariyet_net.Concrete;
using _16_Eylul_Kariyet_net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.Controllers;

[AllowAnonymous]
public class RegisterController : Controller
{
    //DEPENDENCY INJECTION YÖNTEMİ YARIN ANLATILACAK.
    private readonly UserManager<Kullanici> _userManager;
    
    public RegisterController(UserManager<Kullanici> userManager)
    {
        _userManager = userManager;
        
    }
    
    
     
     [HttpGet]
     public IActionResult Talent()
     {
         return View();
     }
     
     [HttpPost]
     public async Task<IActionResult> Talent(IsArayanViewModel p)
     {
         if (ModelState.IsValid)
         {
             Kullanici kullanici = new Kullanici
             {
                 NameSurname = p.NameSurname,
                 Email = p.Mail,
                 UserName = p.UserName
             };
             
           
             
             var result = await _userManager.CreateAsync(kullanici, p.Password);
             //Kayıt olurken user'a rol atama 

             await _userManager.AddToRoleAsync(kullanici, "IsArayan");
             if (result.Succeeded)
             {
                 Context c = new Context();
                 IsArayan ia = new IsArayan();
                 ia.Id = kullanici.Id;
                 //========================================================
                 //DOSYA KISA YOLU ALMA
                 var uzanti = Path.GetExtension(p.Cv.FileName);
                 var yeni_adres = Guid.NewGuid() + uzanti;
                 var konum = Path.Combine(Directory.GetCurrentDirectory(), "CVFILE/", yeni_adres);
                 var stream = new FileStream(konum, FileMode.Create);
                 p.Cv.CopyTo(stream);
                 //========================================================
                 ia.Cv = yeni_adres;
                 c.IsArayans.Add(ia);
                 c.SaveChanges();
                 
                 return RedirectToAction("Index", "Home");
             
             }
             else
             {
                 foreach (var item in result.Errors)
                 {
                     ModelState.AddModelError("",item.Description);
                 }
             }
         }
         return View();
     }
     
     [HttpGet]
     public IActionResult Company()
     {
         return View();
     }
     [HttpPost]
     public async Task<IActionResult> Company(FirmaViewModel f)
     {
         
         
         if (ModelState.IsValid)
         {
             Kullanici kullanici = new Kullanici
             {
                 NameSurname = f.NameSurname,
                 Email = f.Mail,
                 UserName = f.UserName
             };
             
           
             
             var result = await _userManager.CreateAsync(kullanici, f.Password);
             //Kayıt olurken user'a rol atama 

             await _userManager.AddToRoleAsync(kullanici, "Firma");
             if (result.Succeeded)
             {
                 Context c = new Context();
                 Firma firma = new Firma();
                 firma.FirmaAdi = f.FirmaAdi;
                 firma.Id = kullanici.Id;
                 firma.FirmaAciklama = f.FirmaAciklama;
                 
                 //========================================================
                 //DOSYA KISA YOLU ALMA
                 var uzanti = Path.GetExtension(f.Gorsel.FileName);
                 var yeni_adres = Guid.NewGuid() + uzanti;
                 var konum = Path.Combine(Directory.GetCurrentDirectory(), "CVFILE/", yeni_adres);
                 var stream = new FileStream(konum, FileMode.Create);
                 f.Gorsel.CopyTo(stream);
                 //========================================================
                 firma.FirmaGorsel = yeni_adres;
                 c.Firmas.Add(firma);
                 c.SaveChanges();
                 
                 return RedirectToAction("Index", "Home");
             
             }
             else
             {
                 foreach (var item in result.Errors)
                 {
                     ModelState.AddModelError("",item.Description);
                 }
             }
         }
         
         
         
         return View();
     }
}