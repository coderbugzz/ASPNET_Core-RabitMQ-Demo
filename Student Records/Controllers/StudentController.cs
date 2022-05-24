using Microsoft.AspNetCore.Mvc;
using Student_Records.Data;
using Student_Records.DTO;
using Student_Records.Services;

namespace Student_Records.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentDbContext _context;
        private readonly IMessageProducer _messagePublisher;

        public StudentController(IStudentDbContext context, IMessageProducer messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewStudent(StudentDto studentDto)
        {
            Student student = new()
            {
                StudentName = studentDto.StudentName,
                Age = studentDto.Age,
                CourseTitle = studentDto.CourseTitle
            };

            _context.Student.Add(student);

            await _context.SaveChangesAsync();

            _messagePublisher.SendMessage(student);

            return Ok(new { id = student.StudentId });
        }

    }
}
