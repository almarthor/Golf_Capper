using Golf_Capper.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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



        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Golfer>().HasData(
                new Golfer
                {
                    GolferId = 1,
                    FirstName = "Almar",
                    LastName = "Egilsson",
                    Handicap = 12
                }
           );
            Builder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    City = "Hafnarfjörður",
                    Address = "Hvaleyrarbraut",
                    Zip = 220
                }
           );
            Builder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Hvaleyrarvöllur",
                    NumberOfHoles = 18,
                    CoursePar = 71,
                    LocationId = 1
                }
           );
            Builder.Entity<CourseHolePar>().HasData(
              new CourseHolePar
              {
                  CourseHoleParId = 1,
                  HoleNumber = 1,
                  Par = 4,
                  CourseId = 1,
              }
         );
            Builder.Entity<GamePlayed>().HasData(
             new GamePlayed
             {
                 GamePlayedId = 1,
                 GolferId = 1,
                 CourseId = 1,
                 LoadedFromDatabase = DateTime.Now,
             }
        );
            Builder.Entity<Score>().HasData(
             new Score
             {
                 ScoreId = 1,
                 Hole = 1,
                 Strokes = 4,
                 GamePlayedId = 1,
             }
        );

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GolfCapper");
        }

         
    }
}
