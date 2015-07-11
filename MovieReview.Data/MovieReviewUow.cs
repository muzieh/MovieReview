using System.Data.Entity;
using MovieReview.Data.Contracts;
using MovieReview.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieReview.Data
{
    public class MovieReviewUow : IMovieReviewUow, IDisposable
    {
        public MovieReviewUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = _dbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Model.Movie> Movies
        {
            get { return GetStandardRepo<Movie>(); }
        }

        public IRepository<Model.MoviesReview> MovieReviews
        {
            get { return GetStandardRepo<MoviesReview>(); }
        }

        private MovieReviewDBContext _dbContext;
        protected IRepositoryProvider RepositoryProvider { get; set; }

        private void CreateDbContext()
        {
            _dbContext = new MovieReviewDBContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }


        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
