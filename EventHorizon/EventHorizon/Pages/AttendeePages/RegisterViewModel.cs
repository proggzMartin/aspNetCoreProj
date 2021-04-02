using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHorizon.Pages.AttendeePages
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Confirm Password")] //display this instead of ConfirmPassword in one word.
        public string ConfirmPassword { get; set; }
    }
}
