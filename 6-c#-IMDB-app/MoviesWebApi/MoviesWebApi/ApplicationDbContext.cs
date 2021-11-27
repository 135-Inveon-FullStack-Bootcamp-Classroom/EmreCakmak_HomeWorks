using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>()
                .HasKey(x => new { x.ActorId, x.MovieId });// Making Composite Primary Key
            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new { x.GenreId, x.MovieId });// Making Composite Primary Key
           
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }// Relationship Movies and Actors
        public DbSet<MoviesGenres> MoviesGenres { get; set; }// Relationship Movies and Genres
        public DbSet<Rating> Ratings { get; set; }
    }
}
