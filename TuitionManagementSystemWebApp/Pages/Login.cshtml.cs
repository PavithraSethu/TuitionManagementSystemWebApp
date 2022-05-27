using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace TuitionManagementSystemWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public LoginModel()
        {
            UserName = "";
            Password = "";
            ErrorMessage = "";
            SuccessMessage = "";

        }
        public void OnGet()
        {
        }

        public async void OnPost()
        {


            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Login or Password";
                return;
            }

            if (UserName == "Student" && Password == "Student")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("StudentId","1"),
                    new Claim(ClaimTypes.Name, "Student"),
                    new Claim(ClaimTypes.Role, "Student")
                };



                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);



                Response.Redirect("/Index");
                return;
            }

            else if (UserName == "Admin1" && Password == "Admin")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("AdminId","1"),
                    new Claim(ClaimTypes.Name, "Trainer"),
                    new Claim(ClaimTypes.Role, "Trainer")
                };



                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);



                Response.Redirect("/Index");
                return;
            }


            ErrorMessage = "Invalid Login or Password";
        }
    }
}
