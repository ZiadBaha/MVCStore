using Microsoft.AspNetCore.Mvc;
using MovieStoreMvx.Models.DTO;
using MovieStoreMvx.Repositories.Abstract;

namespace MovieStoreMvx.Controllers
{
    public class UserAuthentcationController : Controller
    {
        private IUserAuthentcationService authervice { get; set; }
        public UserAuthentcationController(IUserAuthentcationService authervice)
        {
            this.authervice = authervice;
        }

        /* We will create a user with admin rights, after that we are going
         to comment this method because we need only
         one user in this application 
        */


        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "ziad77566@gmail.com",
        //        Username = "admin",
        //        Name = "ziad",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "Admin"

        //    };
        //    // if you register with user change Role ="user"
        //    var result = await authervice.RegisterAsync(model);
        //    return Ok(result.Message);
        //}
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var result = await authervice.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authervice.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

