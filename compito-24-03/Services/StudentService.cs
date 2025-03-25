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

        public async Task<Student?> GetStudentByEmail(string email)
        {
            try
            {
                return await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteStudent(string email)
        {
            try
            {
                var student = await GetStudentByEmail(email);
                if (student == null)
                {
                    return false;
                }
                _context.Students.Remove(student);
                return await SaveSync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudent(string email, Student student)
        {
            try
            {
                var studente = await GetStudentByEmail(email);
                if (student == null)
                {
                    return false;
                }
                studente.Nome = student.Nome;
                studente.Cognome = student.Cognome;
                studente.Email = student.Email;

                return await SaveSync();
            }
            catch
            {
                return false;
            }
        }
    }
}
