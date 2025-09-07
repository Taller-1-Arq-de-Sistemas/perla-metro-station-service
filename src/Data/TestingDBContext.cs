using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stationService.src.Model;

namespace stationService.src.Data
{
    public class TestingDBContext : DbContext
    {
        public TestingDBContext(DbContextOptions<TestingDBContext> options) : base(options)
        {
        }


        public DbSet<Station> Stations { get; set; } = null!;
    }
}