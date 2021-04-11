using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventHorizon.Pages.AttendeePages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }
        SignInManager<IdentityUser> _signInManager;
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    LoginViewModel.Email,
                    LoginViewModel.Password,
                    false,
                    false
                );

                if(result.Succeeded)
                {
                    TempData["justLoggedIn"] = true;
                    return Redirect("/Index");
                }

                ModelState.AddModelError("IncorrectPassword", "Email or password was incorrect, please try again.");
            }
                
            return Page();
        }
    }
}
