using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdlMovie
{
    public class Movie
    {
        public Movie()
        {

        }

        public Movie(int id, string title, string actrees, double rating)
        {
            Id = id;
            Title = title;
            Actrees = actrees;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Actrees { get; set; }
        public double Rating { get; set; }

        private int mMovieYear;

        public int MovieYear
        {
            get
            {
                // something doing here
                return mMovieYear;
            }
            set
            {
                mMovieYear = value;
            }
        }


    }
}
