using MovieReview.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data
{
    public class MovieReviewUow : IMovieReviewUow
    {

        public IRepository<Model.Movie> Movies
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Model.MoviesReview> MovieReviews
        {
            get { throw new NotImplementedException(); }
        }
    }
}
