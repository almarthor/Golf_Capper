using Golf_Capper.Models;

namespace Golf_Capper.Data.Interface
{
    public interface Irepository
    {
        // Get
        Task<List<Course>> GetAllCoursesAsync();
        List<CourseHolePar> GetAllCourseHoleParsAsync();
        List<GamePlayed> GetAllGamesPLayedAsync();
        List<Golfer> GetAllGolfersAsync();
        List<Location> GetAllLocationsAsync();
        List<Score> GetAllScoresAsync();
        // GetByID
        Task<Course> GetCourseById(int id);
        CourseHolePar GetCourseHoleParById(int id);
        GamePlayed GetGamePlayedById(int id);
        Golfer GetGolferById(int id);
        Location GetLocationById(int id);
        Score GetScoreById(int id);
        //Create
        Task CreateCourseAsync(Course course);
        void CreateCourseHolePar(CourseHolePar courseHolePar);
        void CreateGamePlayed(GamePlayed gamePlayed);
        void CreateGolfer(Golfer golfer);
        void CreateLocation(Location location);
        void CreateScore(Score score);
        //update
        Task<Course> UpdateCourse(int id, Course course);
        CourseHolePar UpdateCourseHolePar(int id, CourseHolePar courseHolePar);
        Golfer UpdateGolfer(int id, Golfer golfer);
        Location UpdateLocation(int id, Location location);
        Score UpdateScore(int id, Score score);
        //Delete
        Task<bool> DeleteCourse(int id);
        bool DeleteCourseHolePar(int id);
        bool DeleteGamePlayed(int id);
        bool DeleteGolfer(int id);
        bool DeleteLocation(int id);
     
        bool DeleteScore(int id);
        
    }
}
