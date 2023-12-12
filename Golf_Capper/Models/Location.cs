using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Location
    {
       
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public int Zip {  get; set; }
        public string Address { get; set; }
        

    }
}
