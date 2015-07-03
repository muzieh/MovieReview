using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MovieReview.Data
{
    public class MoviewReviewDatabaseInitializer : DropCreateDatabaseIfModelChanges<MovieReviewDBContext>
    {
        protected override void Seed(MovieReviewDBContext context)
        {
            base.Seed(context);
        }
    }
}
