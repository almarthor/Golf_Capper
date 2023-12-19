using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Score
    {
       
       
        [Key]
        public int ScoreId { get; set; }
        public int Hole { get; set; }
        public int Strokes {  get; set; }

        //navi

        public int? GamePlayedId { get; set; }
        public GamePlayed GamesPlayed { get; set; }


    }
}
