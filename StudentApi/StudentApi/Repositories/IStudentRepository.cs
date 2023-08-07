using StudentApi.DataModels;

namespace StudentApi.Repositories
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);

        Task<bool> UpdateProfileImage(Guid studentId,string profileImageUrl);



    }
}
