using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroservicetwo.Models;

public class ComplaintDbContext : DbContext
{

    public ComplaintDbContext(DbContextOptions<ComplaintDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Complaint> Complaints { get; set; }
}
