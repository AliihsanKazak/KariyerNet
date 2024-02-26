using System.ComponentModel.DataAnnotations;

namespace _16_Eylul_Kariyet_net.Models;

public class FirmaViewModel:UserSignUpViewModel
{
    [Required(ErrorMessage = "Lütfen Firma Adı giriniz")]
    public string FirmaAdi { get; set; }
     
     
    [Required(ErrorMessage = "Lütfen FirmaAciklama giriniz")]
    public string FirmaAciklama { get; set; }
    
    
    [Required(ErrorMessage = "Lütfen Görsel Ekleyiniz")]
    public IFormFile Gorsel { get; set; }
     
    
     
     
    
}