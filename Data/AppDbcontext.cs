using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Entity;

namespace WebApplication2.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
        {
            
        }

        public DbSet<Student> students { get; set; }
    }
}
