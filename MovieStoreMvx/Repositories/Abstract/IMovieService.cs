using MovieStoreMvx.Models.Domain;
using MovieStoreMvx.Models.DTO;

namespace MovieStoreMvx.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        bool Update(Movie model);
        Movie GetById(int id);
        bool Delete(int id);
        MovieListVm List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetGenresByMovieId(int movieID);
    }
}
