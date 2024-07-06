using Microsoft.AspNetCore.Identity;

namespace MovieStoreMvx.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
