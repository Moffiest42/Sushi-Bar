using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sushi_Bar.Models;

namespace Sushi_Bar.Data
{
    public class Sushi_BarContext : DbContext
    {
        public Sushi_BarContext (DbContextOptions<Sushi_BarContext> options)
            : base(options)
        {
        }

        public DbSet<Sushi_Bar.Models.Dish> Dish { get; set; } = default!;
        public DbSet<Sushi_Bar.Models.Ingredient> Ingredients { get; set; } = default!;
        public DbSet<Sushi_Bar.Models.Order> Orders { get; set; } = default!;
    }
}
