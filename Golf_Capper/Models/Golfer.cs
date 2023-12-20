using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Golfer
    {
        [Key]
        public int GolferId { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        public int Handicap { get; set; }

        
    }
    
}
