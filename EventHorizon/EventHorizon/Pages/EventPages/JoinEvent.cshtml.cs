using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventHorizon.Data;
using EventHorizon.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventHorizon.Pages.EventPages
{
    public class JoinEvent : PageModel
    {

        public SelectList AttendeeSelect { get; set; }


        public Event Event { get; set; } = new Event();

        [BindProperty]
        public Attendee ChosenAttendee { get; set; } = new Attendee();

        public string Message { get; set; }

        public bool Joined { get; set; }


        private readonly EventHorizonContext _context;

        public JoinEvent(EventHorizonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event
                .Include(x => x.Organizer).FirstOrDefaultAsync(m => m.Id.Equals(id));

            var q = await _context.Attendee.AsNoTracking().ToListAsync();

            AttendeeSelect = new SelectList(q, "Id", "Name");

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }

        public void OnPost()
        {   
            Joined = true;
        }

    }
}
