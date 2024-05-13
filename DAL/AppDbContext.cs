using _13MayWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _13MayWebApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
