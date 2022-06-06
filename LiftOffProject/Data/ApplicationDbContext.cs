using LiftOffProject.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<Notes> Notes { get; set; } 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<WineNote>()
                .HasKey(j => new { j.WineId, j.NotesId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
