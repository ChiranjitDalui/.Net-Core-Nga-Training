using EF_DB_Demo.Models;

namespace EF_DB_Demo.Data
{
    public static class DbInitializer
    {
        public static void Seed(TrainingContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.Add(new Student { Name = "Chiranjit" });
                context.Trainers.Add(new Trainer { Name = "Prof. Sen" });
                context.Courses.Add(new Course { Title = "C# Basics" });
                context.SaveChanges();
            }
        }
    }
}
