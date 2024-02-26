using System;
namespace _16_Eylul_Kariyet_net.Models
{
	public class Kategori
	{
		public int KategoriID { get; set; }

		public string KategoriAdi { get; set; }

		public string KategoriGorsel { get; set; }



		public ICollection<Jobs> Jobses  { get; set; }

	}
}

