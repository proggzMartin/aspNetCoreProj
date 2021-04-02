﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventHorizon.Data
{
    public class EventHorizonIdentityContext : IdentityDbContext
    {
        public EventHorizonIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
