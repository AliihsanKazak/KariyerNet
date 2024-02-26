using System;
namespace _16_Eylul_Kariyet_net.Models
{
	public class Jobs
	{

		public int JobsID { get; set; }

		public string Aciklama { get; set; }

		public string Sorumluluklar { get; set; }

        public string Yetenekler { get; set; }

		public double Maas { get; set; }

		public int BasvuruSayisi { get; set; }

        public DateTime YayinTarihi { get; set; }

        public DateTime YayinBitisTarihi { get; set; }

     

        //KATEGORİ TABLOSUYLA İLİŞKİ KURMA

        public int? KategoriID { get; set; }

		public Kategori Kategori { get; set; }

        //ÇALIŞMA TÜRÜ TABLOSUYLA İLİŞKİ KURMA

        public int? CalismaTuruID { get; set; }

        public CalismaTuru CalismaTuru { get; set; }

       


        //FİRMA İLE İLİŞKİ KURMA

		
        public string? FirmaId { get; set; }

        public Firma Firma { get; set; }

       
        //SEHİR İLE İLİŞKİ KURMA


        public int? SehirID { get; set; }

        public Sehir Sehir { get; set; }
    }
}

