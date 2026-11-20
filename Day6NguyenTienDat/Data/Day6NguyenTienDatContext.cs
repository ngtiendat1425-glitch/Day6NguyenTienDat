using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day6NguyenTienDat.Models;

namespace Day6NguyenTienDat.Data
{
    public class Day6NguyenTienDatContext : DbContext
    {
        public Day6NguyenTienDatContext (DbContextOptions<Day6NguyenTienDatContext> options)
            : base(options)
        {
        }

        public DbSet<Day6NguyenTienDat.Models.Product> Product { get; set; } = default!;
        public DbSet<Day6NguyenTienDat.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Day6NguyenTienDat.Models.Movice> Movice { get; set; } = default!;
    }
}
