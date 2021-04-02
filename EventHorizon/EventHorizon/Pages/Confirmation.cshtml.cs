using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventHorizon.Pages
{
    public class ConfirmationModel : PageModel
    {

        public string Message { get; set; }
        public void OnGet()
        {
        }


        public void OnGetRegistration()
        {
            Message = "The user were successfully registered.";
        }

        public void OnGetFeedback()
        {
            Message = "Thank you for taking time providing us with feedback!";
        }
    }
}
