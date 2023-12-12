using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Golfer
    {
        [Key]
        public int GolferId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Handicap { get; set; }
    }
}
