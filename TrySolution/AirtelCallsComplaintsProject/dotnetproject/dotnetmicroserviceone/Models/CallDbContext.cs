using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroserviceone.Models;

public class CallDbContext : DbContext
{
    public CallDbContext()
    {
    }

    public CallDbContext(DbContextOptions<CallDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Call> Calls { get; set; }

}
