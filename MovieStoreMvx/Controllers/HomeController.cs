using Microsoft.AspNetCore.Mvc;
using MovieStoreMvx.Repositories.Abstract;
using MovieStoreMvx.Repositories.Implementation;

namespace MovieStoreMvx.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index(string term="",  int currentPage = 1)
        {
            var movie = _movieService.List(term , true , currentPage);
            return View(movie);
        }
        public IActionResult about()
        {
            return View();
        }

        public IActionResult MovieDetail(int movieId)
        {
            var movie = _movieService.GetById(movieId);
            return View(movie);
        }
    }
}
