using AlumniProject.Dto;
using AlumniProject.Entity;

namespace AlumniProject.Service
{
    public interface IAlumniToClassService
    {
        Task<int> CreateAlumniToClass(AlumniToClass alumniToClass);
        //Task<AccessRequest> UpdateAlumniToClass(int accessRequestId, int status);
        //Task<Alumni> GetAlumniByClassId(int classId);
        Task<int> CountAlumniByClassid (int classId);
        Task<IEnumerable<int>> GetClassIdByAlumniId(int alumniId);

        Task DeleteAlumniToClass(int id);
        //Task<PagingResultDTO<AccessRequest>> GetAccessRequestsByScchoolId(int pageNo, int pageSiz, int schoolId);
        //Task<bool> IsRequestExist(int alumniId, int classId);
    }
}
