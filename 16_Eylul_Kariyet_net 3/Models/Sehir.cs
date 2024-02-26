using System;
namespace _16_Eylul_Kariyet_net.Models
{
	public class Sehir
	{
		public int SehirID { get; set; }

		public string SehirAdi { get; set; }

		//ULKE TABLOSUYLA ARASINDA BİR İLİŞKİ KURDUK

		public int UlkeID { get; set; }

		public Ulke Ulke { get; set; }


		public ICollection<Jobs> Jobses { get; set; }

    }
}

