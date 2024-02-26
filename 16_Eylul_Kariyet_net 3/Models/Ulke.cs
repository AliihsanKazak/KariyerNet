using System;
namespace _16_Eylul_Kariyet_net.Models
{
	public class Ulke
	{
		public int UlkeID { get; set; }

		public string UlkeAdi { get; set; }


		

		public ICollection<Sehir> Sehirs { get; set; }
	}
}

