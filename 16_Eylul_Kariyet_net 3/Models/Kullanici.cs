using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace _16_Eylul_Kariyet_net.Models;

public class Kullanici:IdentityUser
{
    public string NameSurname { get; set; }
    
    
    
    
    
    
}
