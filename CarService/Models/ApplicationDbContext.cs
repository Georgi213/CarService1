using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        Database.EnsureCreated();
    }

        public DbSet<Klient> Klient { get; set; } = default!;

        public DbSet<Tellimus> Tellimus { get; set; }

        public DbSet<Autoteenus> Autoteenus { get; set; }

        public DbSet<Tootaja> Tootaja { get; set; }
    }
