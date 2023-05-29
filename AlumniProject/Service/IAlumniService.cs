using AlumniProject.Dto;
using AlumniProject.Entity;

namespace AlumniProject.Service
{
    public interface IAlumniService
    {
        Task<PagingResultDTO<Alumni>> GetAll(int pageNo, int pageSize);
        Task<Alumni> GetById(int id);
        Task<bool> DeleteById(int id);
        Task<Alumni> UpdateAlumni(Alumni alumni);
        Task<int> AddAlumni(Alumni alumni);
        Task<Alumni> GetAlumniByEmail(string email); 
    }
}
