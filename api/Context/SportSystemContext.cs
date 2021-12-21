using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Model;

namespace SportSystemAPI.Context
{
    public class SportSystemContext : DbContext
    {
        public SportSystemContext(DbContextOptions<SportSystemContext> opt) : base(opt)
        {

        }

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WorkoutModel> Workouts { get; set; }
        public DbSet<WorkoutRegistrationModel> WorkoutRegistrations { get; set; }
    }
}