using MovieStoreMvx.Models.DTO;

namespace MovieStoreMvx.Repositories.Abstract
{
    public interface IUserAuthentcationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
        //Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);

    }
}
