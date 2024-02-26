using System.ComponentModel.DataAnnotations;

namespace _16_Eylul_Kariyet_net.Models;

public class IsArayanViewModel:UserSignUpViewModel
{
    
    
    [Required(ErrorMessage = "Lütfen CV Ekleyiniz")]
    public IFormFile Cv { get; set; }
}