using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Data.Contracts
{
    public interface IRepositoryProvider
    {
        MovieReviewDBContext DbContext { get; set; }

        IRepository<T> GetRepository<T>() where T : class;
    }
}
