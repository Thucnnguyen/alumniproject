
using AlumniProject.Data.Repostitory;
using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Ultils;

namespace AlumniProject.Service.ServiceImp
{
    public class AccessRequestService : IAlumniRequestService
    {
        private readonly Lazy<IAlumniService> alumniService;
        private readonly Lazy<IAlumniToClassService> alumniToClassService;
        private readonly Lazy<ISchoolService> schoolService;
        private readonly Lazy<IGradeService> gradeService;
        private readonly Lazy<IClassService> classService;
        private readonly IAccessRequestRepo accessRequestRepo;
        public AccessRequestService(
            Lazy<IAlumniService> service,
            Lazy<ISchoolService> shoolService,
            Lazy<IGradeService> gradeService,
            Lazy<IClassService> classService,
            Lazy<IAlumniToClassService> alumniToClassService,
        IAccessRequestRepo accessRequestRepo)
        {
            this.alumniService = service;
            this.schoolService = shoolService;
            this.gradeService = gradeService;
            this.accessRequestRepo = accessRequestRepo;
            this.classService = classService;
            this.alumniToClassService = alumniToClassService;
        }

        public async Task<int> CreateAlumniRequest(AccessRequest accessRequest)
        {
            var isExisted = await IsRequestExist(accessRequest.Email, accessRequest.AlumniClassId);
            if (isExisted)
            {
                throw new ConflictException("AccessRequest is exist");
            }
            var isClassExisted = await classService.Value.GetClassById(accessRequest.AlumniClassId);
            if(isClassExisted== null)
            {
                throw new NotFoundException("Class not found with id: "+ accessRequest.AlumniClassId);
            }
            var schoolId = (await gradeService.Value.GetGradeById(isClassExisted.GradeId)).SchoolId;
            accessRequest.SchoolId = schoolId;
            var alumniRequestId = await accessRequestRepo.CreateAsync(accessRequest);
            return alumniRequestId;
        }

        public async Task<AccessRequest> GetAccessRequestsById(int id)
        {
            var accessRequest = await accessRequestRepo.GetByIdAsync( a => a.Archived == true&& a.Id == id);
            if (accessRequest == null)
            {
                throw new NotFoundException("RequestId not found with id: "+id);
            }
            return accessRequest;
        }

        public async Task<PagingResultDTO<AccessRequest>> GetAccessRequestsByScchoolId(int pageNo,int pageSize, int schoolId)
        {
            var school = await schoolService.Value.GetSchoolById(schoolId);
            if(school == null)
            {
                throw new NotFoundException("School not found with id: " + schoolId);
            }
            var accessRequestList = await accessRequestRepo
                .GetAllByConditionAsync(pageNo, pageSize, a => a.SchoolId == schoolId && a.Archived == true);
            return accessRequestList;
        }

        
        public async Task<AccessRequest> UpdateAccessRequest(int accessRequestId, int status)
        {
            var existedAccess = await GetAccessRequestsById(accessRequestId);
            if(existedAccess == null)
            {
                throw new NotFoundException("AccessRequest not found with id: " + accessRequestId);
            }
            
            existedAccess.RequestStatus = status;
            if(status == 2)
            {
                var alumni = await alumniService.Value.GetAlumniByEmail(existedAccess.Email.Trim());
                if(alumni == null)
                {
                    var newAlumni = new Alumni()
                    {
                        FullName = existedAccess.FullName,
                        Email = existedAccess.Email,
                        Phone = existedAccess.Phone,
                        DateOfBirth = existedAccess.DateOfBirth,
                        schoolId = existedAccess.SchoolId,
                        RoleId = (int)RoleEnum.alumni,
                    };
                    var newAlumniId = await alumniService.Value.AddAlumni(newAlumni);
                    var newAlumniToClass = new AlumniToClass()
                    {
                        AlumniId = newAlumniId,
                        ClassId = existedAccess.AlumniClassId,
                    };
                    await alumniToClassService.Value.CreateAlumniToClass(newAlumniToClass);
                }
            }
            await accessRequestRepo.UpdateAsync(existedAccess);
            return existedAccess;
        }



        public async Task<bool> IsRequestExist(string email, int classId)
        {
            var request = await accessRequestRepo.FindOneByCondition(a => a.Email == email && a.AlumniClassId == classId && a.Archived == true);
            if (request == null)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteAccessRequest(int accessRequestId)
        {
            var existedAccess = await GetAccessRequestsById(accessRequestId);
            if (existedAccess == null)
            {
                throw new NotFoundException("AccessRequest not found with id: " + accessRequestId);
            }
            existedAccess.Archived = false;
            await accessRequestRepo.UpdateAsync(existedAccess);
        }
    }
}
