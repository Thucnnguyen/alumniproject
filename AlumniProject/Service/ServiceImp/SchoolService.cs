using AlumniProject.Data.Repostitory;
using AlumniProject.Entity;


namespace AlumniProject.Service.ServiceImp
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepo repository;

        public SchoolService(ISchoolRepo schoolRepo)
        {
            this.repository = schoolRepo;
        }
        public async Task<int> AddSchool(School school)
        {
            var ExistName = await repository.FindOneByCondition(s => s.Name == school.Name);
            if (ExistName != null)
            {
                throw new Exception("School's Name is existed");
            }
            else
            {
                var ExistSubdomain = await repository.FindOneByCondition(s => s.SubDomain == school.SubDomain);
                if (ExistSubdomain !=null)
                {
                    throw new Exception("School's Subdomain is existed");
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

        public Task DeleteSchool(School school)
        {
            throw new NotImplementedException();
        }

        public async Task<School> GetSchoolById(int schoolId)
        {
            var school = await repository.GetByIdAsync(schoolId);
            return school;
        }

        public async Task<School> GetSchoolBySubDomain(string schoolSubDomain)
        {
            var school = await repository.FindOneByCondition(s => s.SubDomain == schoolSubDomain);
            return school;
        }

        public async Task<School> UpdateSchool(School school)
        {
            School schoolToUpdate = await repository.FindOneByCondition( s => s.Id == school.Id);
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
                await repository.UpdateAsync(schoolToUpdate);
                return schoolToUpdate;
            }
            else
            {
                throw new Exception("School not found with ID:" + school.Id);
            }
        }
    }
}
