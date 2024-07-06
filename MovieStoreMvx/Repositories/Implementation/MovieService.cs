using MovieStoreMvc.Models.Domain;
using MovieStoreMvx.Models.Domain;
using MovieStoreMvx.Models.DTO;
using MovieStoreMvx.Repositories.Abstract;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace MovieStoreMvx.Repositories.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext ctx;

        public MovieService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Movie model)
        {
            try
            {
                ctx.Movie.Add(model);
                ctx.SaveChanges();
                foreach (int genreId in model.Genres)
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = model.Id,
                        GenreId = genreId
                    };
                    ctx.MovieGenre.Add(movieGenre);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                var MovieGenres = ctx.MovieGenre.Where(a => a.MovieId == data.Id);
                foreach (var movieGenre in MovieGenres)
                {
                    ctx.MovieGenre.Remove(movieGenre);
                }
                ctx.Movie.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Movie GetById(int Id)
        {
            return ctx.Movie.Find(Id);
        }

        public MovieListVm List(string term = "", bool paging = false, int currentPage = 0)
        {
            var data = new MovieListVm();
       

            var list = ctx.Movie.ToList();
            
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a => a.Title.ToLower().StartsWith(term)).ToList();
            }

            if (paging)
            {                
                // here will will aplly pagin
                int pagesize = 8;
                int count = list.Count;
                int TotalPages = (int) Math.Ceiling(count / (double)pagesize);
                list = list.Skip((currentPage - 1)*pagesize).Take(pagesize).ToList();
                data.PageSize = pagesize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
             

            foreach (var movie in list)
            {
                var genres = (from genre in ctx.Genre
                              join mg in ctx.MovieGenre
                              on genre.Id equals mg.GenreId
                              where mg.MovieId == movie.Id
                              select genre.GenreName
                              ).ToList();
                var genreNames = string.Join(',', genres);
                movie.GenerNames = genreNames;
            }
            ////////////////////
            data.MovieList = list.AsQueryable();
          
            return data;
        }

        public bool Update(Movie model)
{
    try
    {
        var genresToDelete = ctx.MovieGenre.Where(a => a.MovieId == model.Id && !model.Genres.Contains(a.GenreId)).ToList();
        foreach (var mgenre in genresToDelete)
        {
            ctx.MovieGenre.Remove(mgenre);
        }
        foreach (int genId in model.Genres)
        {
            var movieGenre = ctx.MovieGenre.FirstOrDefault(a => a.MovieId == model.Id && a.GenreId == genId);
            if (movieGenre == null)
            {
                movieGenre = new MovieGenre
                {
                    GenreId = genId,
                    MovieId = model.Id
                };
                ctx.MovieGenre.Add(movieGenre);
            }
        }
        ctx.Movie.Update(model);

        ctx.SaveChanges();
        return true;
    }
    catch (Exception ex)
    {
        return false;
    }
}

public List<int> GetGenresByMovieId(int movieID)
{
    var genreIds = ctx.MovieGenre.Where(a => a.MovieId == movieID).Select(a => a.GenreId).ToList();
    return genreIds;
}
    }
}
