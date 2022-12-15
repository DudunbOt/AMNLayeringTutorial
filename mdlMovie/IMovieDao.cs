using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdlMovie
{
    public interface IMovieDao
    {
        Movie Insert(Movie newMovie);
        bool Update(Movie movie, int id);
        bool Delete(int id);
        Movie GetById(int id);
        List<Movie> GetAll();
        long GetCount();
    }
}
