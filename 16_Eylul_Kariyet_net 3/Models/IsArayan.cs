using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16_Eylul_Kariyet_net.Models;

public class IsArayan
{
    [Key,ForeignKey("Kullanici")]
    public string Id { get; set; }

    public Kullanici Kullanici { get; set; }
    
    
    public string Cv { get; set; }
    
    
}