using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.FundooContext
{
    public class FundooDBContext : DbContext
    {
        // A DbContext instance represents a session with the database and can be used to query and save the intances of  your entities.
        // DbContext is a combination of the Unit of Work and Repository patterns.
        public FundooDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Label { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.email)
            .IsUnique();

        }
    }
}
