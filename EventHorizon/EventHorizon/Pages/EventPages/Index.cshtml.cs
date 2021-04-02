﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventHorizon.Data.Entities;

namespace EventHorizon.Pages.EventPages
{
    public class IndexModel : PageModel
    {
        private readonly EventHorizon.Data.EventHorizonContext _context;

        public IndexModel(EventHorizon.Data.EventHorizonContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event
                .Include(x => x.Organizer).ToListAsync();
        }
    }
}
