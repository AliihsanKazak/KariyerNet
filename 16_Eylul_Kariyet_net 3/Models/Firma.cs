using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16_Eylul_Kariyet_net.Models
{
	public class Firma
	{

		
		[Key,ForeignKey("Kullanici")]
		public string Id { get; set; }

		public Kullanici Kullanici { get; set; }
		
		public string FirmaAdi { get; set; }

		public string FirmaAciklama { get; set; }

        public string FirmaGorsel { get; set; }

        
        public ICollection<Jobs> Jobses { get; set; }	
        
        
    }
}

