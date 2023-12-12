using Golf_Capper.Models;
using Microsoft.EntityFrameworkCore;

namespace Golf_Capper.Data
{
    public class GolfCapperDbcontext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseHolePar> CourseHolePars { get; set; }
        public DbSet<GamePlayed> GamesPlayed { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GolfCapper");
        }
    }
}
