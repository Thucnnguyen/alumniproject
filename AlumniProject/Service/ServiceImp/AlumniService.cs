using AlumniProject.Data.Repostitory;
using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;

namespace AlumniProject.Service.ServiceImp
{
    public class AlumniService : IAlumniService
    {

        private readonly IAlumniRepo _repo;
        public AlumniService(IAlumniRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> AddAlumni(Alumni newAlumni)
        {
            var alumni = await GetAlumniByEmail(newAlumni.Email);
            if(alumni != null)
            {
                throw new ConflictException("Alumni was existed with email: "+newAlumni.Email);
            }
            var newAlumniId = await _repo.CreateAsync(newAlumni);
            return newAlumniId;
        }

        public async Task<bool> DeleteById(int id)
        {
            var existAlumni = GetById(id);
            if(existAlumni == null)
            {
                return false;
            }
             await _repo.DeleteByIdAsync(id);
            return true;
        }

        public async Task<PagingResultDTO<Alumni>> GetAll(int pageNo, int pageSize)
        {
            var AlumniList = await _repo.GetAllByConditionAsync(pageNo,pageSize,null);
            return AlumniList;
        }

        public async Task<Alumni> GetAlumniByEmail(string email)
        {
            var alumni = await _repo.FindOneByCondition(a => a.Email == email && a.Archived == true);
            return alumni;
        }

        public async Task<Alumni> GetById(int id)
        {
            var alumni = await _repo.GetByIdAsync(a => a.Id == id, a=> a.Archived == true);
            return alumni;
        }

        public async Task<Alumni> GetTenantBySchoolId(int schoolId)
        {
            var alumni = await _repo.FindOneByCondition(a => a.schoolId == schoolId && a.IsOwner == true && a.Archived == true);
            return alumni;
        }

        public async Task<Alumni> UpdateAlumni(Alumni alumni)
        {

            Alumni updateAlumni = await GetById(alumni.Id);
            updateAlumni.Bio = alumni.Bio;
            updateAlumni.FullName = alumni.FullName;
            updateAlumni.DateOfBirth = alumni.DateOfBirth;
            updateAlumni.Avatar_url = alumni.Avatar_url;
            updateAlumni.CoverImage_url = alumni.CoverImage_url;
            updateAlumni.Phone = alumni.Phone;
            updateAlumni.Bio = alumni.Bio;
            await _repo.UpdateAsync(updateAlumni);
            
            return updateAlumni;
        }
    }
}
