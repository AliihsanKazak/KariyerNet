using System;
using _16_Eylul_Kariyet_net.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.ViewComponents.Category
{
	public class Category:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			Context c = new Context();

			var kategoriler = c.Kategoris.ToList();

			return View(kategoriler);
		}



	}
}

