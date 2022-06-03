using LiftOffProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace LiftOffProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<WineCategory> WineCategories { get; set; }
        public DbSet<WineNote> WineNotes { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
