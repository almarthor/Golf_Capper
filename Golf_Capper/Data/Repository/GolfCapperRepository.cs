using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Golf_Capper.Data.Repository
{
    public class GolfCapperRepository : Irepository
    {
        private readonly GolfCapperDbcontext _dbcontext;

        public GolfCapperRepository()
        {
            _dbcontext = new GolfCapperDbcontext();
        }

        //Create
        public async Task CreateCourseAsync(Course course)
        {
            using(var db = _dbcontext) 
            {
                await db.Courses.AddAsync(course);
                await db.SaveChangesAsync();
            }
        }

        public void CreateCourseHolePar (CourseHolePar courseHolePar)
        {
            using(var db = _dbcontext)
            {
                 db.CourseHolePars.Add(courseHolePar);
                 db.SaveChanges();
            }
        }

        public void CreateGamePlayed(GamePlayed gamePlayed)
        {
            using(var db = _dbcontext)
            {
                db.GamesPlayed.Add(gamePlayed);
                db.SaveChanges();
            }
        }

        public void CreateGolfer(Golfer golfer)
        {
            using(var db = _dbcontext) 
            {
                db.Golfers.Add(golfer);
                db.SaveChanges();
            }
        }

        public void CreateLocation(Location location)
        {
            using(var db = _dbcontext)
            {
                db.Locations.Add(location);
                db.SaveChanges();
            }
        }

        public void CreateScore(Score score)
        {
            using(var db = _dbcontext)
            {
                db.Scores.Add(score);
                db.SaveChanges();
            }
        }

        //Delete
        public async Task<bool> DeleteCourse(int id)
        {
            Course courseToDelete;
            using(var db = _dbcontext)
            {
                courseToDelete = await db.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

                if (courseToDelete == null) 
                {
                    return false;
                }
                else
                {
                    db.Courses.Remove(courseToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }

        public bool DeleteCourseHolePar(int id)
        {
            CourseHolePar courseHoleParToDelete;
            using (var db = _dbcontext)
            {
                courseHoleParToDelete = db.CourseHolePars.FirstOrDefault(h => h.CourseHoleParId == id);

                if (courseHoleParToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.CourseHolePars.Remove(courseHoleParToDelete);
                    db.SaveChanges(true);
                    return true;
                }
            }
        }

        public bool DeleteGamePlayed(int id)
        {
            GamePlayed GamePlayedToDelete;
            using (var db = _dbcontext)
            {
                GamePlayedToDelete = db.GamesPlayed.FirstOrDefault(g => g.GamePlayedId == id);

                if (GamePlayedToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.GamesPlayed.Remove(GamePlayedToDelete);
                    db.SaveChanges(true);
                    return true;
                }
            }
        }

        public bool DeleteGolfer(int id)
        {
            Golfer GolferToDelete;
            using (var db = _dbcontext)
            {
                GolferToDelete = db.Golfers.FirstOrDefault(g => g.GolferId == id);

                if (GolferToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Golfers.Remove(GolferToDelete);
                    db.SaveChanges(true);
                    return true;
                }
            }
        }

        public bool DeleteLocation(int id)
        {
            Location LocationToDelete;
            using (var db = _dbcontext)
            {
                LocationToDelete = db.Locations.FirstOrDefault(l => l.LocationId == id);

                if (LocationToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Locations.Remove(LocationToDelete);
                    db.SaveChanges(true);
                    return true;
                }
            }
        }

        public bool DeleteScore(int id)
        {
            Score ScoreToDelete;
            using (var db = _dbcontext)
            {
                ScoreToDelete = db.Scores.FirstOrDefault(s => s.ScoreId == id);

                if (ScoreToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Scores.Remove(ScoreToDelete);
                    db.SaveChanges(true);
                    return true;
                }
            }
        }


        //GetAll
        public List<CourseHolePar> GetAllCourseHoleParsAsync()
        {
            using (var db = _dbcontext)
            {
                return db.CourseHolePars.ToList();
            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            using (var db = _dbcontext)
            {
                return await db.Courses.ToListAsync();
            }
        }

        public List<GamePlayed> GetAllGamesPLayedAsync()
        {
            using (var db = _dbcontext)
            {
                return  db.GamesPlayed.ToList();
            }
        }

        public   List<Golfer> GetAllGolfersAsync()
        {
            using (var db = _dbcontext)
            {
                return  db.Golfers.ToList();
            }
        }

        public List<Location> GetAllLocationsAsync()
        {
            
            using (var db = _dbcontext)
            {
                return db.Locations.ToList();
            }
        }

        public List<Score> GetAllScoresAsync()
        {
            
            using (var db = _dbcontext)
            {
                return  db.Scores.ToList();
            }
            
        }

        //GetById

        public async Task<Course?> GetCourseById(int id)
        {
            Course? c;
            using (var db = _dbcontext)
            {
                
                c = await db.Courses.Include(l => l.Location).FirstOrDefaultAsync(x => x.CourseId == id);
                
                return c;
            }
        }

        public CourseHolePar? GetCourseHoleParById(int id)
        {
            using(var db = _dbcontext)
            {
                CourseHolePar? c = db.CourseHolePars.Include(z => z.Course).FirstOrDefault(x => x.CourseHoleParId == id);
                return c;
            }
        }

        public GamePlayed? GetGamePlayedById(int id)
        {
            using(var db = _dbcontext)
            {
                GamePlayed? g = db.GamesPlayed
                    .Include(z => z.Golfer)
                    .Include(c => c.Course)
                    .FirstOrDefault(x => x.GamePlayedId == id);
                return g;
            }
        }

        public Golfer? GetGolferById(int id)
        {
            using(var db = _dbcontext)
            {
                Golfer? g = db.Golfers.FirstOrDefault(x => x.GolferId == id);
                return g;
            }
        }

        public Location? GetLocationById(int id)
        {
            using(var db = _dbcontext)
            {
                Location? l = db.Locations.FirstOrDefault(x => x.LocationId == id);
                return l;
            }
        }

        public Score? GetScoreById(int id)
        {
            using(var db = _dbcontext)
            {
                Score? s = db.Scores
                    .Include(z => z.GamePlayed.Golfer)
                    .Include(r => r.GamePlayed.Course)
                    .FirstOrDefault(x => x.ScoreId == id);
                return s;
            }
        }

        //Update

        public async Task<Course> UpdateCourse(int id, Course course)
        {
            Course CourseToUpdate;
            using(var db = _dbcontext)
            {
                
                CourseToUpdate = await db.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
                if(CourseToUpdate == null)
                {
                    return null;
                }
                CourseToUpdate.CoursePar = course.CoursePar;
                CourseToUpdate.CourseName = course.CourseName;
                CourseToUpdate.NumberOfHoles = course.NumberOfHoles;
                await db.SaveChangesAsync();
                return CourseToUpdate;




            }
        }

        public CourseHolePar UpdateCourseHolePar(int id, CourseHolePar courseHolePar)
        {
            CourseHolePar CourseHoleParToUpdate;
            using(var db = _dbcontext)
            {
                CourseHoleParToUpdate = db.CourseHolePars.FirstOrDefault(x => x.CourseHoleParId == id);
                if(CourseHoleParToUpdate == null)
                {
                    return null;
                }
                CourseHoleParToUpdate.HoleNumber = courseHolePar.HoleNumber;
                CourseHoleParToUpdate.Par = courseHolePar.Par;
                db.SaveChanges();
                return CourseHoleParToUpdate;

            }
        }

        

        public Golfer UpdateGolfer(int id, Golfer golfer)
        {
            Golfer GolferToUpdate;
            using(var db = _dbcontext)
            {
                GolferToUpdate = db.Golfers.FirstOrDefault(x => x.GolferId == id);
                if(GolferToUpdate == null)
                {
                    return null;
                }
                GolferToUpdate.FirstName = golfer.FirstName;
                GolferToUpdate.LastName = golfer.LastName;
                GolferToUpdate.Handicap = golfer.Handicap;
                db.SaveChanges();
                return GolferToUpdate;
            }
        }

        public Location UpdateLocation(int id, Location location)
        {
            Location LocationToUpdate;
            using (var db = _dbcontext)
            {
                LocationToUpdate = db.Locations.FirstOrDefault(x => x.LocationId == id);
                if (LocationToUpdate == null)
                {
                    return null;
                }
                LocationToUpdate.City = location.City;
                LocationToUpdate.Zip = location.Zip;
                LocationToUpdate.Address = location.Address;
                db.SaveChanges ();
                return LocationToUpdate;


            }
        }

        public Score UpdateScore(int id, Score score)
        {
            Score ScoreToUpdate;
            using (var db = _dbcontext)
            {
                ScoreToUpdate = db.Scores.FirstOrDefault(x => x.ScoreId == id);
                if (ScoreToUpdate == null)
                {
                    return null;
                }
                ScoreToUpdate.Hole = score.Hole;
                ScoreToUpdate.Strokes = score.Strokes;
                db.SaveChanges () ;
                return ScoreToUpdate;




            }
        }

    } 

}
