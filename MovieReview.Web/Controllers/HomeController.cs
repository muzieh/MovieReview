using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReview.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			var f = new MovieReview.Data.RepositoryFactories();
			var repP = new MovieReview.Data.RepositoryProvider(f);	
			var uow = new MovieReview.Data.MovieReviewUow(repP);
			var movie = uow.Movies.GetAll().OrderBy(m => m.Id).First();

			return View();
		}
	}
}