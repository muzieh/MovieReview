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
	public class MovieReviewsController : ApiBaseController
	{
		public MovieReviewsController(IMovieReviewUow uow)
		{
			this.Uow = uow;
		}

		// GET: api/MovieReviews
		public IEnumerable<MoviesReview> Get()
		{
			return this.Uow.MovieReviews.GetAll().OrderBy(r => r.MovieId);
		}

		// GET: api/MovieReviews/5
		public IEnumerable<MoviesReview> Get(int id)
		{
			return this.Uow.MovieReviews.GetAll().Where(m => m.MovieId == id);	
		}

		[System.Web.Http.ActionName("getbyreviewername")]
		public MoviesReview GetByReviewerName(string value)
		{
			var review = this.Uow.MovieReviews.GetAll().FirstOrDefault(m => m.ReviewerName.StartsWith(value));
			if (review != null)
				return review;

			throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
		}
		
		public HttpResponseMessage Put([FromBody] MoviesReview review)
		{
			this.Uow.MovieReviews.Update(review);
			this.Uow.Commit();
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}

		// POST: api/MovieReviews
		public HttpResponseMessage Post([FromBody] MoviesReview review, int Id)
		{
			review.MovieId = Id;	
			this.Uow.MovieReviews.Add(review);
			this.Uow.Commit();
			var response = Request.CreateResponse(HttpStatusCode.Created, review);
			return response;
		}


		// DELETE: api/MovieReviews/5
		public HttpResponseMessage Delete(int id)
		{
			this.Uow.MovieReviews.Delete(id);
			this.Uow.Commit();
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}
	}
}