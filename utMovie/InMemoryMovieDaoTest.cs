using daoInMemoryMovie;
using mdlMovie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace utMovie
{
    [TestClass]
    public class InMemoryMovieDaoTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var data = new Movie()
            {
                Title = "Test Title",
                Actrees = "Test Actress",
                MovieYear = 9999,
                Rating = 5
            };

            IMovieDao movieDao = new InMemoryMovieDao();
            var actual = movieDao.Insert(data);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Id > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var data = new Movie()
            {
                Title = "Test Title",
                Actrees = "Test Actress",
                MovieYear = 9999,
                Rating = 5
            };

            var expected = new Movie()
            {
                Title = "Edited",
                Actrees = "Actrees Edited",
                MovieYear = 1111,
                Rating = 9
            };

            IMovieDao movieDao = new InMemoryMovieDao();
            var actual = movieDao.Insert(data);

            //take data
            actual = movieDao.GetById(actual.Id);
            Assert.IsNotNull(actual);

            actual.Title = "Edited";
            actual.Actrees = "Actrees Edited";
            actual.MovieYear = 1111;
            actual.Rating = 9;

            var result = movieDao.Update(actual, actual.Id);
            Assert.IsTrue(result);

            actual = movieDao.GetById(actual.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Actrees, actual.Actrees);
            Assert.AreEqual(expected.MovieYear, actual.MovieYear);
            Assert.AreEqual(expected.Rating, actual.Rating);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var data = new Movie()
            {
                Title = "Test Title",
                Actrees = "Test Actress",
                MovieYear = 9999,
                Rating = 5
            };

            IMovieDao movieDao = new InMemoryMovieDao();
            var actual = movieDao.Insert(data);
            Assert.IsNotNull(actual);

            //delete
            var result = movieDao.Delete(actual.Id);
            Assert.IsTrue(result);

            //get ulang
            actual = movieDao.GetById(actual.Id);
            Assert.IsNull(actual);
        }
    }
}
