
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventHorizon.Pages
{
    public class ConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public void OnPostLogout()
        {

        }


        public void OnGetRegistration(string s)
        {
            Message = "The user were successfully registered.";
        }

        public void OnGetFeedback()
        {
            Message = "Thank you for taking time providing us with feedback!";
        }
    }
}
