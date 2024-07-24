using Microsoft.EntityFrameworkCore;
using MvcProject.Models.Entities;

namespace MvcProject.BloggDbContext
{
    public class StudentContext:DbContext
    {

        public StudentContext(DbContextOptions options):base(options) {
        
        }
       
       public DbSet<Student> students { get; set; }


    }
}
