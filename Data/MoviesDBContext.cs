using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data
{
    public class MoviesDBContext : IdentityDbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesDAL> Movies { get; set; }

    }
}
