namespace EF_DB_Demo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        // Email will be added later via migration
        // now add Emial
       
        public string Email { get; set; } 

        
    }
}
