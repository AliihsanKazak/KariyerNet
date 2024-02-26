using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16_Eylul_Kariyet_net.Models;

public class BasvuruLog
{
    [Key]
    public int BasvuruLogID { get; set; }
    
 
    public int JobsID { get; set; }

    public Jobs Jobs { get; set; }
    
  
    public string KullaniciId { get; set; }

    public Kullanici Kullanici { get; set; }
    
}