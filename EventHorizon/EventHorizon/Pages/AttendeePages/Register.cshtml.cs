﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventHorizon.Data;
using EventHorizon.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventHorizon.Pages.AttendeePages
{
    public class RegisterModel : PageModel
    {
        private readonly EventHorizonContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public RegisterModel(EventHorizonContext context, 
                             UserManager<IdentityUser> userManager,
                             SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser()
                {
                    UserName = RegisterViewModel.Email,
                    Email = RegisterViewModel.Email
                };

                var result = await _userManager.CreateAsync(newUser, RegisterViewModel.Password); //The password is hashed and stored.

                if(result.Succeeded)
                {
                    //redirect to success.
                    //Email user.
                    //Brew coffe

                    //isPersistent sets if we want to store a session-cookie at user webbrowser or a 'permanent' cookie.
                    //We want session, so isPersistent is set to false.
                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    return RedirectToPage("/Confirmation", "Registration");
                }

                //If there were errors, loop through them.
                foreach (var error in result.Errors) 
                {
                    //Add them to the modelstate.
                    ModelState.AddModelError("", error.Description); 
                }
            }
            else
            {

            }
            return Page();

        }

        //Convention: OnPostFeedback - Feedback is the same as 'asp-page-handler="Feedback"' in the page.
        public IActionResult OnPostFeedback(string message)
        {
            _context.UserFeedback.Add(new UserFeedback() { Feedback = message });
            _context.SaveChanges();

            return new RedirectToPageResult("/Confirmation", "Feedback");
        }
    }
}
