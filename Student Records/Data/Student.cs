using System.ComponentModel.DataAnnotations;
namespace Student_Records.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int Age { get; set; }
        public string CourseTitle { get; set; }
    }
}
