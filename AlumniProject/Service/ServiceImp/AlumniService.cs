using AlumniProject.Data.Repostitory;
using AlumniProject.Dto;
using AlumniProject.Entity;

namespace AlumniProject.Service.ServiceImp
{
    public class AlumniService : IAlumniService
    {

        private readonly IAlumniRepo _repo;
        public AlumniService(IAlumniRepo repo)
        {
            _repo = repo;
        }

        public Task<int> AddAlumni(Alumni alumni)
        {
            var isSuccess = _repo.CreateAsync(alumni);
            return isSuccess;
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
            var alumni = await _repo.GetAlumniByEmail(email);
            return alumni;
        }

        public async Task<Alumni> GetById(int id)
        {
            var alumni = await _repo.GetByIdAsync(id);
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
