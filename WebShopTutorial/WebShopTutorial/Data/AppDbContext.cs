using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
