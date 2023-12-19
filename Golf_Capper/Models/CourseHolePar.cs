using System.ComponentModel.DataAnnotations;

namespace Golf_Capper.Models
{
    public class CourseHolePar
    {
       
        
        [Key]
        public int CourseHoleParId { get; set; }
        public int HoleNumber { get; set; }
        public int Par {  get; set; }

        //navi

        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}
