using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.EntityFrameworkCore;
using Golf_Capper.Data;

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
        public async Task CreateCourse(Course course)
        {
            using (var db = _dbcontext)
            {
                await db.Courses.AddAsync(course);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateCourseHolePar(CourseHolePar courseHolePar)
        {
            using (var db = _dbcontext)
            {
                await db.CourseHolePars.AddAsync(courseHolePar);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateGamePlayed(GamePlayed gamePlayed)
        {
            using (var db = _dbcontext)
            {
                await db.GamesPlayed.AddAsync(gamePlayed);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateGolfer(Golfer golfer)
        {
            using (var db = _dbcontext)
            {
                await db.Golfers.AddAsync(golfer);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateLocation(Location location)
        {
            using (var db = _dbcontext)
            {
                await db.Locations.AddAsync(location);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateScore(Score score)
        {
            using (var db = _dbcontext)
            {
                await db.Scores.AddAsync(score);
                await db.SaveChangesAsync();
            }
        }

        //Delete
        public async Task<bool> DeleteCourseAsync(int id)
        {
            Course courseToDelete;
            using (var db = _dbcontext)
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

        public async Task<bool> DeleteCourseHoleParAsync(int id)
        {
            CourseHolePar courseHoleParToDelete;
            using (var db = _dbcontext)
            {
                courseHoleParToDelete = await db.CourseHolePars.FirstOrDefaultAsync(h => h.CourseHoleParId == id);

                if (courseHoleParToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.CourseHolePars.Remove(courseHoleParToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }

        public async Task<bool> DeleteGamePlayedAsync(int id)
        {
            GamePlayed GamePlayedToDelete;
            using (var db = _dbcontext)
            {
                GamePlayedToDelete = await db.GamesPlayed.FirstOrDefaultAsync(g => g.GamePlayedId == id);

                if (GamePlayedToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.GamesPlayed.Remove(GamePlayedToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }

        public async Task<bool> DeleteGolferAsync(int id)
        {
            Golfer GolferToDelete;
            using (var db = _dbcontext)
            {
                GolferToDelete = await db.Golfers.FirstOrDefaultAsync(g => g.GolferId == id);

                if (GolferToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Golfers.Remove(GolferToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            Location LocationToDelete;
            using (var db = _dbcontext)
            {
                LocationToDelete = await db.Locations.FirstOrDefaultAsync(l => l.LocationId == id);

                if (LocationToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Locations.Remove(LocationToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }

        public async Task<bool> DeleteScoreAsync(int id)
        {
            Score ScoreToDelete;
            using (var db = _dbcontext)
            {
                ScoreToDelete = await db.Scores.FirstOrDefaultAsync(s => s.ScoreId == id);

                if (ScoreToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Scores.Remove(ScoreToDelete);
                    await db.SaveChangesAsync(true);
                    return true;
                }
            }
        }


        //GetAll
        public async Task<List<CourseHolePar>> GetAllCourseHoleParsAsync()
        {
            using (var db = _dbcontext)
            {
                return await db.CourseHolePars.ToListAsync();
            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            using (var db = _dbcontext)
            {
                return await db.Courses.ToListAsync();
            }
        }

        public async Task<List<GamePlayed>> GetAllGamesPLayedAsync()
        {
            using (var db = _dbcontext)
            {
                return await db.GamesPlayed.ToListAsync();
            }
        }

        public async Task<List<Golfer>> GetAllGolfersAsync()
        {
            using (var db = _dbcontext)
            {
                return await db.Golfers.ToListAsync();
            }
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {

            using (var db = _dbcontext)
            {
                return await db.Locations.ToListAsync();
            }
        }

        public async Task<List<Score>> GetAllScoresAsync()
        {

            using (var db = _dbcontext)
            {
                return await db.Scores.ToListAsync();
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

        public async Task<CourseHolePar?> GetCourseHoleParById(int id)
        {
            CourseHolePar? c;
            using (var db = _dbcontext)
            {
                c = await db.CourseHolePars.Include(z => z.Course).FirstOrDefaultAsync(x => x.CourseHoleParId == id);
                return c;
            }
        }

        public async Task<GamePlayed?> GetGamePlayedById(int id)
        {
            GamePlayed? g;
            using (var db = _dbcontext)
            {
                g = await db.GamesPlayed.Include(z => z.Golfer)
                                        .Include(c => c.Course)
                                        .FirstOrDefaultAsync(x => x.GamePlayedId == id);
                return g;
            }
        }

        public async Task<Golfer?> GetGolferById(int id)
        {
            Golfer? g;
            using (var db = _dbcontext)
            {
                g = await db.Golfers.FirstOrDefaultAsync(x => x.GolferId == id);
                return g;
            }
        }

        public async Task<Location?> GetLocationById(int id)
        {
            Location? l;
            using (var db = _dbcontext)
            {
                l = await db.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
                return l;
            }
        }

        public async Task<Score?> GetScoreById(int id)
        {
            Score? s;
            using (var db = _dbcontext)
            {
                s = await db.Scores
                    .Include(z => z.GamesPlayed)
                    
                    .FirstOrDefaultAsync(x => x.ScoreId == id);
                return s;
            }
        }

        //Update

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            Course UpdatedCourse;
            using (var db = _dbcontext)
            {
                UpdatedCourse = await db.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
                if (UpdatedCourse == null)
                {
                    return null;
                }
                UpdatedCourse.CoursePar = course.CoursePar;
                UpdatedCourse.CourseName = course.CourseName;
                UpdatedCourse.NumberOfHoles = course.NumberOfHoles;
                await db.SaveChangesAsync();
                return UpdatedCourse;
            }
        }

        public async Task<CourseHolePar> UpdateCourseHoleParAsync(int id, CourseHolePar courseHolePar)
        {
            CourseHolePar CourseHoleParToUpdate;
            using (var db = _dbcontext)
            {
                CourseHoleParToUpdate = await db.CourseHolePars.FirstOrDefaultAsync(x => x.CourseHoleParId == id);
                if (CourseHoleParToUpdate == null)
                {
                    return null;
                }
                CourseHoleParToUpdate.HoleNumber = courseHolePar.HoleNumber;
                CourseHoleParToUpdate.Par = courseHolePar.Par;
                await db.SaveChangesAsync();
                return CourseHoleParToUpdate;

            }
        }



        public async Task<Golfer> UpdateGolferAsync(int id, Golfer golfer)
        {
            Golfer GolferToUpdate;
            using (var db = _dbcontext)
            {
                GolferToUpdate = await db.Golfers.FirstOrDefaultAsync(x => x.GolferId == id);
                if (GolferToUpdate == null)
                {
                    return null;
                }
                GolferToUpdate.FirstName = golfer.FirstName;
                GolferToUpdate.LastName = golfer.LastName;
                GolferToUpdate.Handicap = golfer.Handicap;
                await db.SaveChangesAsync();
                return GolferToUpdate;
            }
        }

        public async Task<Location> UpdateLocationAsync(int id, Location location)
        {
            Location LocationToUpdate;
            using (var db = _dbcontext)
            {
                LocationToUpdate = await db.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
                if (LocationToUpdate == null)
                {
                    return null;
                }
                LocationToUpdate.City = location.City;
                LocationToUpdate.Zip = location.Zip;
                LocationToUpdate.Address = location.Address;
                await db.SaveChangesAsync();
                return LocationToUpdate;


            }
        }

        public async Task<Score> UpdateScoreAsync(int id, Score score)
        {
            Score ScoreToUpdate;
            using (var db = _dbcontext)
            {
                ScoreToUpdate = await db.Scores.FirstOrDefaultAsync(x => x.ScoreId == id);
                if (ScoreToUpdate == null)
                {
                    return null;
                }
                ScoreToUpdate.Hole = score.Hole;
                ScoreToUpdate.Strokes = score.Strokes;
                ScoreToUpdate.GamePlayedId = score.GamePlayedId;
                await db.SaveChangesAsync();
                return ScoreToUpdate;




            }
        }

    }

}
