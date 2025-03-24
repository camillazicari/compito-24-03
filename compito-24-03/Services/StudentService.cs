using compito_24_03.Data;
using compito_24_03.Models;
using Microsoft.EntityFrameworkCore;

namespace compito_24_03.Services
{
    public class StudentService
    {
        public readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveSync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                return await SaveSync();
            }
            catch
            {
                return false;
            }

        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch
            {
                return null;

            }
        }
    }
}
