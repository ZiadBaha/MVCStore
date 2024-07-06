using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStoreMvx.Models.Domain;
using MovieStoreMvx.Repositories.Abstract;
using System.Security.Cryptography.X509Certificates;


namespace MovieStoreMvx.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IFilleService _filleService;
        private readonly IGenreService _genService;

        public MovieController(IMovieService movieService , IFilleService filleService , IGenreService genService)
        {
            _movieService = movieService;
            _filleService = filleService;
            _genService = genService;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }

        // Add
        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._filleService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                     //////
                     return View(model);
                    ///////
                }
                var imageName = fileReult.Item2;
                model.MovieImage = imageName;
           }
            var result = _movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }


        // Edite
        public IActionResult Edit(int id)
        {
            var model = _movieService.GetById(id);
            var selectedgenres = _movieService.GetGenresByMovieId(model.Id);
            MultiSelectList multiSelectList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedgenres);
            model.MultiGenreList = multiSelectList;
          
            return View(model);
        }

        // update
        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            var selectedgenres = _movieService.GetGenresByMovieId(model.Id);
            MultiSelectList multiSelectList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedgenres);
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var FileResult = this._filleService.SaveImage(model.ImageFile);
                if (FileResult.Item1 == 0)
                {
                    TempData["msg"] = "File Could Not Saved";
                    return View(model);
                }
                var ImageName = FileResult.Item2;
                model.MovieImage = ImageName;

            }
            var result = _movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(MovieList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }
        //list
        public IActionResult MovieList()
        {
            var data = this._movieService.List();
            return View(data);
            //return ok(data);
        }


        // Delete
        public IActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);
            return RedirectToAction(nameof(MovieList));
        }



    }
}

