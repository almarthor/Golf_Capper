using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class GamePlayed
    {
        
        
        [Key]
        public int GamePlayedId { get; set; }
        public DateTime LoadedFromDatabase { get; set; }

        //navi

        public int? GolferId { get; set; }
        public Golfer? Golfer { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }





    }
}
