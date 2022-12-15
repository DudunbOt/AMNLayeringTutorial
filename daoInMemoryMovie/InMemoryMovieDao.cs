using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mdlMovie;

namespace daoInMemoryMovie
{
    public class InMemoryMovieDao : mdlMovie.IMovieDao
    {
        private static List<Movie> movieList = new List<Movie>();
        private static int id = 0;
        public bool Delete(int id)
        {
            var oldData = GetById(id);
            if (oldData == null)
                return false;  

            movieList.Remove(GetById(id));

            return true;
        }

        public List<Movie> GetAll()
        {
            return movieList;
        }

        public Movie GetById(int id)
        {
            var data = movieList.Where(e => e.Id == id).FirstOrDefault();
            return data;
        }

        public long GetCount()
        {
            return movieList.Count();
        }

        public Movie Insert(Movie newMovie)
        {
            id++;
            newMovie.Id = id;
            movieList.Add(newMovie);
            return newMovie;

        }

        public bool Update(Movie movie, int id)
        {
            if(!movieList.Any(e => e.Id == id))
                return false;

            var oldData = GetById(id);
            if (oldData == null)
                return false;

            oldData.Title = movie.Title;
            oldData.Actrees = movie.Actrees;
            oldData.MovieYear = movie.MovieYear;
            oldData.Rating = movie.Rating;

            return true;
        }
    }
}
