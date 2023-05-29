using AlumniProject.Entity;

namespace AlumniProject.Service;

public interface ISchoolService
{
    Task<int> AddSchool(School school);
    Task<School> UpdateSchool(School school);
    Task DeleteSchool(School school);
    Task<School> GetSchoolById(int schoolId);   
    Task<School> GetSchoolBySubDomain(string schoolSubDomain);
}
    