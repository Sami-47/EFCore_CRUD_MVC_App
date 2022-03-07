using Microsoft.EntityFrameworkCore;
using Subject_Mangement_App.Models;

namespace Subject_Mangement_App.Context
{
    public class SubjectContext : DbContext
    {
        public SubjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
    }
}
