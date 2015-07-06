using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieReview.Data.Contracts;
using MovieReview.Model;

namespace MovieReview.Web.Controllers
{
	public class MoviesController : ApiBaseController 
	{
		public MoviesController(IMovieReviewUow uow)
		{
			this.Uow = uow;
		}
		
		// GET: api/Moviews
		public IEnumerable<Movie> Get()
		{
			return this.Uow.Movies.GetAll().OrderBy(s => s.MovieName);
		}

		// GET: api/Moviews/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Moviews
		public void Post([FromBody]
						 string value)
		{
		}

		// PUT: api/Moviews/5
		public void Put(int id, [FromBody]
						string value)
		{
		}

		// DELETE: api/Moviews/5
		public void Delete(int id)
		{
		}
	}
}