using System;
namespace _16_Eylul_Kariyet_net.Models
{
	public class CalismaTuru
	{
		public int CalismaTuruID { get; set; }

		public string CalismaTuruAdi { get; set; }





        public ICollection<Jobs> Jobses { get; set; }
    }
}

