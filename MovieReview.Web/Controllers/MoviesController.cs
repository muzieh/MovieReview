using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReview.Data.Contracts;
using MovieReview.Model;

namespace MovieReview.Web.Controllers
{
	public class MoviesController : ApiBaseController 
	{
        /*
		public MoviesController(IMovieReviewUow uow)
		{
			this.Uow = uow;
		}
        */
		
		// GET: api/Moviews
		public IQueryable Get()
		{
			var model = Uow.Movies.GetAll().OrderByDescending(m => m.Reviews.Count())
				.Select(m => new MovieViewModel
				{
					Id = m.Id,
					DirectorName = m.DirectorName,
					MovieName = m.MovieName,
					ReleaseYear = m.ReleaseYear,
					NoOfReviews = m.Reviews.Count()
				});

			return model;
		}

		// GET: api/Moviews/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Moviews
		public HttpResponseMessage Post([FromBody] Movie movie)
		{
			Uow.Movies.Add(movie);
			Uow.Commit();

			return Request.CreateResponse(HttpStatusCode.Created, movie);
		}

		// PUT: api/Moviews/5
		[HttpPut]
		public HttpResponseMessage Put([FromBody] Movie movie)
		{
			Uow.Movies.Update(movie);
			Uow.Commit();
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}

		// DELETE: api/Moviews/5
		public HttpResponseMessage Delete(int id)
		{
			Uow.Movies.Delete(id);
			Uow.Commit();
			return new HttpResponseMessage(HttpStatusCode.NoContent); 
		}
	}
}