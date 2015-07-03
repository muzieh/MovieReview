using MovieReview.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MovieReview.Data
{
    public class MovieReviewDBContext : DbContext
    {
        public MovieReviewDBContext() : base(nameOrConnectionString:"moviewsReviewProd") 
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesReview> MoviesReviews { get; set;}

        static MovieReviewDBContext()
        {
            Database.SetInitializer(new MoviewReviewDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
