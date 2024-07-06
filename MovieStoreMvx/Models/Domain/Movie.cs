using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreMvx.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ReleaseYear { get; set; }

        public string? MovieImage { get; set; }  // stores movie image name with extension (eg, image0001.jpg)
        [Required]
        public string? Cast { get; set; }
        [Required]
        public string? Director { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int> ? Genres { get; set; }
        [NotMapped]

        //{ get; set; }//
        public IEnumerable<SelectListItem> ? GenreList { get; set; }
        //////////////////
        [NotMapped]
        public string ? GenerNames { get; set; }
        //////////////////
        [NotMapped]
        public MultiSelectList ? MultiGenreList  { get; set; }



    }
}
