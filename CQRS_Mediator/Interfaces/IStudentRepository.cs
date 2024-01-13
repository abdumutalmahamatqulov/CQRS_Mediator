using CQRS_Mediator.Models;

namespace CQRS_Mediator.Interfaces;

public interface IStudentRepository
{
    public Task<List<Student>> GetStudentListAsync();
    public Task<Student> GetStudentByIdAsync(int Id);
    public Task<Student> AddStudentAsync(Student studentDetails);
    public Task<int> UpdateStudentAsync(Student studentDetails);
    public Task<int> DeleteStudentAsync(int Id);
}
