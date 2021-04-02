using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventHorizon.Data.Entities
{
    public class Attendee : IdentityUser
    {
        public int Id { get; set; }

        /* 
            Attributen är till för validation som används vid modelbinding typ; på AttendeePages/Register, 
            finns en post där dessa kommer till hands och validerar fälten.
            Även i codebehind när ModelState.Valid körs, returnar det true om att nedan attribute's uppfylls.
         */
        [Required, MinLength(2)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public override string Email { get; set; }
        [Required, Phone]
        public override string PhoneNumber { get; set; }

        public ICollection<Event> Event { get; set; }

    }
}
