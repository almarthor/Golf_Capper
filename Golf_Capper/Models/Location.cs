using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Location
    {
       
        [Key]
        public int LocationId { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        public int Zip {  get; set; }
        [MaxLength(255)]
        public string Address { get; set; }

        
    }
}
