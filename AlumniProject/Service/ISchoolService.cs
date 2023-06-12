using AlumniProject.Dto;
using AlumniProject.Entity;

namespace AlumniProject.Service;

public interface ISchoolService
{
    Task<int> AddSchool(School school);
    Task<School> UpdateSchool(School school);
    Task<School> UpdateSchoolStatus(int schoolId,int status);
    Task DeleteSchool(School school);
    Task<School> GetSchoolById(int schoolId);
    Task<School> GetSchoolBySubDomain(string schoolSubDomain);

    Task<bool> IsExistedSchool(int id);
    Task<PagingResultDTO<School>> GetSchools(int pageNo,int pageSize);
}
    