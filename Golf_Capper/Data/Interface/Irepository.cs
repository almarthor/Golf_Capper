using Golf_Capper.Models;

namespace Golf_Capper.Data.Interface
{
    public interface Irepository
    {
        // Get
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<CourseHolePar>> GetAllCourseHoleParsAsync();
        Task<List<GamePlayed>> GetAllGamesPLayedAsync();
        Task<List<Golfer>> GetAllGolfersAsync();
        Task<List<Location>> GetAllLocationsAsync();
        Task<List<Score>> GetAllScoresAsync();
        // GetByID
        Task<Course> GetCourseById(int id);
        Task<CourseHolePar> GetCourseHoleParById(int id);
        Task<GamePlayed> GetGamePlayedById(int id);
        Task<Golfer> GetGolferById(int id);
        Task<Location> GetLocationById(int id);
        Task<Score> GetScoreById(int id);
        //Create
        Task CreateCourse(Course course);
        Task CreateCourseHolePar(CourseHolePar courseHolePar);
        Task CreateGamePlayed(GamePlayed gamePlayed);
        Task CreateGolfer(Golfer golfer);
        Task CreateLocation(Location location);
        Task CreateScore(Score score);
        //update
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<CourseHolePar> UpdateCourseHoleParAsync(int id, CourseHolePar courseHolePar);
        Task<Golfer> UpdateGolferAsync(int id, Golfer golfer);
        Task<Location> UpdateLocationAsync(int id, Location location);
        Task<Score> UpdateScoreAsync(int id, Score score);
        //Delete
        Task<bool> DeleteCourseAsync(int id);
        Task<bool> DeleteCourseHoleParAsync(int id);
        Task<bool> DeleteGamePlayedAsync(int id);
        Task<bool> DeleteGolferAsync(int id);
        Task<bool> DeleteLocationAsync(int id);
     
        Task<bool> DeleteScoreAsync(int id);
        
    }
}
