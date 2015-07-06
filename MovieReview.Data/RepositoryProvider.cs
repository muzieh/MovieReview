using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReview.Data.Contracts;

namespace MovieReview.Data
{
	public class RepositoryProvider : IRepositoryProvider
	{
		private RepositoryFactories repositoryFactories;
		private Dictionary<Type, object> Repositories;

		public RepositoryProvider(RepositoryFactories repositoryFactories)
		{
			this.repositoryFactories = repositoryFactories;
			this.Repositories = new Dictionary<Type, object>();
		}

		public DbContext DbContext { get; set; }

		public IRepository<T> GetRepositoryForEntityType<T>() where T : class
		{
			return GetRepositoryForEntityType<IRepository<T>>(this.repositoryFactories.GetRepositoryFactoryForEntityType<T>());
		}
 
		private T GetRepositoryForEntityType<T>(Func<DbContext, object> factory = null) where T : class
		{
			object repoObj;
			Repositories.TryGetValue(typeof(T), out repoObj);
			if (repoObj != null)
			{
				return (T)repoObj;
			}

			return MakeRepository<T>(factory, DbContext);
		}

		private T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
		{
			var f = factory ?? this.repositoryFactories.GetRepositoryFactory<T>();
			if (f == null)
			{
				throw new NotImplementedException("nie ma factory");
			}

			var repo = (T)f(dbContext);
			Repositories[typeof(T)] = repo;
			return repo;
		}

		public void SetRepository<T>(T repository)
		
		{
			Repositories[typeof(T)] = repository;
		}
	}
 
	public class RepositoryFactories
	{
		private IDictionary<Type, Func<DbContext, object>> GetMovieReviewFactories()
		{
			return new Dictionary<Type, Func<DbContext, object>>
			{
				{ typeof(IRepository<>), dbContext => new RepositoryFactories() }
			};
		}

		public RepositoryFactories()
		{
			_repositoryFactories = GetMovieReviewFactories();
		}

		public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
		{
			_repositoryFactories = factories;
		}

		public Func<DbContext, object> GetRepositoryFactory<T>()
		{
			Func<DbContext, object> factory;
			_repositoryFactories.TryGetValue(typeof(T), out factory);
			return factory;
		}

		public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
		{
			return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
		}

		protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
		{
			return dbContext => new EFRepository<T>(dbContext);
		}

		private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;
	}
}