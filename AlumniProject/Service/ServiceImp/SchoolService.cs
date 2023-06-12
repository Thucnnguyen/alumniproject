using AlumniProject.Data.Repostitory;
using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Ultils;

namespace AlumniProject.Service.ServiceImp
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepo repository;
        private readonly Lazy<IAlumniService> alumniService;

        public SchoolService(ISchoolRepo schoolRepo, Lazy<IAlumniService> alumniService)
        {
            this.repository = schoolRepo;
            this.alumniService = alumniService;
        }
        public async Task<int> AddSchool(School school)
        {
            var ExistName = await repository.FindOneByCondition(s => s.Name == school.Name);
            if (ExistName != null)
            {
                throw new ConflictException("School's Name is existed");
            }
            else
            {
                var ExistSubdomain = await repository.FindOneByCondition(s => s.SubDomain == school.SubDomain);
                if (ExistSubdomain !=null)
                {
                    throw new ConflictException("School's Subdomain is existed");
                }
                else
                {
                    school.StartTime = DateTime.Now;
                    school.EndTime = DateTime.Now.AddMonths(school.Duration);
                    int NewSchoolId = await repository.CreateAsync(school);
                    return NewSchoolId;
                }
            }
        }

        public async Task DeleteSchool(School deletedSchool)
        {
            School school = await GetSchoolById(deletedSchool.Id);
            school.Archived = false;
            await repository.UpdateAsync(school);
        }

        public async Task<School> GetSchoolById(int schoolId)
        {
            var school = await repository.GetByIdAsync(s => s.Id == schoolId, s => s.Archived == true);
            return school;
        }
        
        public async Task<School> GetSchoolBySubDomain(string schoolSubDomain)
        {
            var school = await repository.FindOneByCondition(s => s.SubDomain == schoolSubDomain && s.Archived == true && s.RequestStatus == 2);
            return school;
        }

        public async Task<PagingResultDTO<School>> GetSchools(int pageNo,int pagesize)
        {
            var schoolList = await repository.GetAllByConditionAsync(pageNo,pagesize, s=>s.Archived == true);
            return schoolList;
        }

        

        public async Task<bool> IsExistedSchool(int schoolId)
        {
            var existedSchool = await GetSchoolById(schoolId);
            if(existedSchool != null)
            {
                return true;
            }
            return false;
        }

        public async Task<School> UpdateSchool(School school)
        {
            School schoolToUpdate = await repository.FindOneByCondition( s => s.Id == school.Id && s.RequestStatus==2 && s.Archived == true);
            if(schoolToUpdate != null)
            {
                schoolToUpdate.Name = school.Name;
                schoolToUpdate.Description = school.Description;
                schoolToUpdate.Theme = school.Theme;
                schoolToUpdate.BackGround1 = school.BackGround1;
                schoolToUpdate.BackGround2 = school.BackGround2;
                schoolToUpdate.BackGround3 = school.BackGround3;
                schoolToUpdate.ProvinceName = school.ProvinceName;
                schoolToUpdate.CityName = school.CityName;
                schoolToUpdate.Address = school.Address;
                schoolToUpdate.Icon = school.Icon;
                schoolToUpdate.SubDomain = school.SubDomain;
                await repository.UpdateAsync(schoolToUpdate);
                return schoolToUpdate;
            }
            else
            {
                throw new NotFoundException("School not found with ID:" + school.Id);
            }
        }

        public async Task<School> UpdateSchoolStatus(int schoolId,int status)
        {
            School schoolToUpdate = await repository.FindOneByCondition(s => s.Id == schoolId && s.Archived == true);
            if (schoolToUpdate != null)
            {
                schoolToUpdate.RequestStatus = status;
                await repository.UpdateAsync(schoolToUpdate);
                if (status == (int)StatusEnum.accept)
                {
                    Alumni tenant = await alumniService.Value.GetTenantBySchoolId(schoolId);
                    if(tenant != null)
                    {
                        tenant.RoleId = (int) RoleEnum.tenant;
                        await alumniService.Value.UpdateAlumni(tenant);
                    }
                }

                    return schoolToUpdate;
            }
            else
            {
                throw new NotFoundException("School not found with ID:" + schoolId);
            }
        }
    }
}
