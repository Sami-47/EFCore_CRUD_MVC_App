using System.ComponentModel.DataAnnotations;

namespace Subject_Mangement_App.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }  
        public string? SubjectName { get; set; }

        public string? SubjectTerm { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
