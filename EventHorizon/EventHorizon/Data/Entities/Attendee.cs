using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventHorizon.Data.Entities
{
    public class Attendee //: IdentityUser messes up primary key, will have to look at this later.
    {
        [Key]
        public int Id { get; set; }

        /* 
            Attributen är till för validation som används vid modelbinding typ; på AttendeePages/Register, 
            finns en post där dessa kommer till hands och validerar fälten.
            Även i codebehind när ModelState.Valid körs, returnar det true om att nedan attribute's uppfylls.
         */
        [Required, MinLength(2)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Event> Event { get; set; }

    }
}
