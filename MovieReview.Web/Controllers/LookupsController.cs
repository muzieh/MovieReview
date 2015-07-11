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
	public class LookupsController : ApiBaseController
	{
		public LookupsController(IMovieReviewUow uow)
		{
			this.Uow = uow;
		}

		[ActionName("movies")]
		public IEnumerable<Movie> GetMovies()
		{
			return this.Uow.Movies.GetAll().OrderBy(m => m.Id);
		}

        [ActionName("movieReviews")]
        public IEnumerable<MoviesReview> GetMoviesReviews()
        {
            return Uow.MovieReviews.GetAll().OrderBy(m => m.MovieId);
        }
	}
}