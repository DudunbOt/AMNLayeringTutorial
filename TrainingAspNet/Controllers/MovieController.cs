using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mdlMovie;
using daoInMemoryMovie;
using bosvcMovieService;

namespace TrainingAspNet.Controllers
{
    public class MovieController : Controller
    {
        private svcMovieService.IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }


        public ActionResult Index()
        {
            var movieList = _movieService.GetAll();
            return View(movieList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Create(FormCollection param)
        {
            Movie movie = new Movie();

            BindData(movie, param);

            if (_movieService.Insert(movie) == null)
            {
                var err = _movieService.GetErrors();
                foreach (var item in err)
                {
                    ModelState.AddModelError(Guid.NewGuid().ToString(), item);
                }

                return View(movie);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = _movieService.GetById(id);
            if(data == null)
            {
                return RedirectToAction("index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _movieService.GetById(id);
            if (data == null)
            {
                return RedirectToAction("index");
            }

            _movieService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = _movieService.GetById(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection param, int id)
        {
            var data = _movieService.GetById(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            BindData(data, param);

            if(_movieService.Update(data, id) == false)
            {
                var err = _movieService.GetErrors();
                foreach(var item in err)
                {
                    ModelState.AddModelError(Guid.NewGuid().ToString(), item);
                }

                return View(data);
            }

            return RedirectToAction("Index");
        }

        private Movie BindData(Movie data, FormCollection param)
        {
            data.Title = param["Title"];
            data.Actrees = param["Actrees"];

            double rating = 0;
            if (double.TryParse(param["Rating"], out rating) == true)
            {
                data.Rating = rating;
            }
            else
            {
                data.Rating = 0;
            }

            return data;
        }
    }
}