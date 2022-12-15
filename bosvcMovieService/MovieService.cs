using mdlMovie;
using System;
using System.Collections.Generic;
using svcMovieService;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bosvcMovieService
{
    public class MovieService : IMovieService
    {

        private readonly IMovieDao _movieDao;
        private readonly List<string> _errors;

        public MovieService()
        {
            _movieDao = new daoInMemoryMovie.InMemoryMovieDao();
            _errors = new List<string>();
        }

        public bool Delete(int id)
        {
            return _movieDao.Delete(id);
        }

        public List<Movie> GetAll()
        {
            return _movieDao.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieDao.GetById(id);
        }

        public long GetCount()
        {
            return _movieDao.GetCount();
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        private bool Validate(Movie newMovie)
        {
            //title harus diisi
            if (string.IsNullOrEmpty(newMovie.Title))
                _errors.Add("Title harus diisi");

            // rating harus 0 <= rating <= 10
            if (newMovie.Rating <= 0 || newMovie.Rating > 10)
                _errors.Add("Rating harus diantara 1 dan 10");

            if (_errors.Count > 0) return false;

            return true;
        }

        public Movie Insert(Movie newMovie)
        {
            if (Validate(newMovie) == false)
                return null;
            
            return _movieDao.Insert(newMovie);
        }

        public bool Update(Movie movie, int id)
        {
            if (Validate(movie) == false)
                return false;

            return _movieDao.Update(movie, id);
        }
    }
}
