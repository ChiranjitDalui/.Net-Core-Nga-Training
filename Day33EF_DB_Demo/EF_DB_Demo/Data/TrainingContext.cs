using Microsoft.EntityFrameworkCore;
using EF_DB_Demo.Models;  

namespace EF_DB_Demo.Data
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
