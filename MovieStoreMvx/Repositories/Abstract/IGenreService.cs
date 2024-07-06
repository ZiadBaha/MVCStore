using MovieStoreMvx.Models.Domain;
using MovieStoreMvx.Models.DTO;

namespace MovieStoreMvx.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
    }
}
