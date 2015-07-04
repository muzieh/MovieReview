using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MovieReview.Data
{
    public class MoviewReviewDatabaseInitializer : DropCreateDatabaseIfModelChanges<MovieReviewDBContext>
    {
        protected override void Seed(MovieReviewDBContext context)
        {
            context.Movies.AddOrUpdate(r => r.MovieName,
                new Model.Movie()
                {
                    MovieName = "Blade Runner",
                    DirectorName = "Ford",
                    ReleaseYear = "1986"
                },
                new Model.Movie()
                {
                    MovieName = "Mad Max",
                    DirectorName = "Sierrone",
                    ReleaseYear = "1983"
                },
                new Model.Movie()
                {
                    MovieName = "Kalakila",
                    DirectorName = "Ramaura",
                    ReleaseYear = "1383",
                    Reviews = new List<Model.MoviesReview>() { new Model.MoviesReview() 
                    {
                        ReviewerName="Kazior", ReviewerRating = 3, ReviewerComments="Superb"
                    }}
                }



                );


        }
    }
}
