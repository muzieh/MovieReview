using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data.Contracts
{
	public interface IRepositoryProvider
	{
		DbContext DbContext { get; set; }
		IRepository<T> GetRepositoryForEntityType<T>() where T : class;
	}
}
