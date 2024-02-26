using System;
using _16_Eylul_Kariyet_net.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _16_Eylul_Kariyet_net.ViewComponents.Carousel
{
	public class Carousel:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			Context c = new Context();

			var carousels = c.Carousels.ToList();

			return View(carousels);
		}


	}
}

