using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class Course
    {
      

        [Key]
        public int CourseId { get; set; }

        [MaxLength(255)]
        public string CourseName { get; set; }
        
        public int CoursePar {  get; set; }
        
        public int NumberOfHoles { get; set; }

        
        public int? LocationId { get; set; }

        public Location? Location { get; set; }

    }
}
