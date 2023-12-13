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
        Task<Course> GetCourseByIdAsync(int id);
        Task<CourseHolePar> GetCourseHoleParByIdAsync(int id);
        Task<GamePlayed> GetGamePlayedByIdAsync(int id);
        Task<Golfer> GetGolferByIdAsync(int id);
        Task<Location> GetLocationByIdAsync(int id);
        Task<Score> GetScoreByIdAsync(int id);
        //Create
        Task CreateCourseAsync(Course course);
        Task CreateCourseHoleParAsync(CourseHolePar courseHolePar);
        Task CreateGamePlayedAsync(GamePlayed gamePlayed);
        Task CreateGolferAsync(Golfer golfer);
        Task CreateLocationAsync(Location location);
        Task CreateScoreAsync(Score score);
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
