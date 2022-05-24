using Microsoft.EntityFrameworkCore;
namespace Student_Records.Data
{
    public interface IStudentDbContext
    {
        DbSet<Student> Student { get; set; }

        Task<int> SaveChangesAsync();
    }
}
