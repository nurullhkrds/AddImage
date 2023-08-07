using Microsoft.EntityFrameworkCore;
using StudentApi.DataModels;
using StudentApi.DTOs;
using Student = StudentApi.DataModels.Student;

namespace StudentApi.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {

        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;


        }


        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.
            FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentAsync(studentId);

            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
