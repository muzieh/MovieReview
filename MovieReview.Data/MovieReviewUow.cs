using System.Data.Entity;
using MovieReview.Data.Contracts;
using System;
using System.Linq;

namespace MovieReview.Data
{
	public class MovieReviewUow : IMovieReviewUow, IDisposable
	{
		public MovieReviewUow(IRepositoryProvider repositoryProvider)
		{
			this.CreateDbContext();
			repositoryProvider.DbContext = DbContext;
			this.RepositoryProvider = repositoryProvider;
		}

		private void CreateDbContext()
		{
			this.DbContext = new MovieReviewDBContext();
			this.DbContext.Configuration.LazyLoadingEnabled = false;
			this.DbContext.Configuration.ProxyCreationEnabled = false;
			this.DbContext.Configuration.ValidateOnSaveEnabled = false;
		}

		public IRepository<Model.Movie> Movies
		{
			get
			{
				return this.GetStandardRepo<Model.Movie>();
			}
		}

		public IRepository<Model.MoviesReview> MovieReviews
		{
			get
			{
				return this.GetStandardRepo<Model.MoviesReview>();
			}
		}

		protected IRepositoryProvider RepositoryProvider { get; set; }
		private DbContext DbContext { get; set; }

		private IRepository<T> GetStandardRepo<T>() where T : class
		{
			return this.RepositoryProvider.GetRepositoryForEntityType<T>();
		}

		public void Commit()
		{
			this.DbContext.SaveChanges();
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.DbContext != null)
				{
					this.DbContext.Dispose();
				}
			}
		}
	}
}
