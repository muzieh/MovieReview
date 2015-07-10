using MovieReview.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public MovieReviewDBContext DbContext { get; set; }

        public IRepository<T> GetRepository<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
