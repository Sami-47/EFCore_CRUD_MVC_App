using System.ComponentModel.DataAnnotations;

namespace Subject_Mangement_App.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string? TeacherName { get; set;}
        public string? TeacherAddress { get; set;} 

        public Subject? Subject { get; set; }
    }
}
