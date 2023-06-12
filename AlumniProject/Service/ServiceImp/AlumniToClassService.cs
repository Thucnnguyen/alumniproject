using AlumniProject.Data.Repostitory;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;

namespace AlumniProject.Service.ServiceImp
{
    public class AlumniToClassService : IAlumniToClassService
    {
        private readonly Lazy<IClassService> _classService;
        private readonly Lazy<IAlumniService> _alumniService;
        private readonly IAlumniToClassRepo _repo;
        public AlumniToClassService(Lazy<IClassService> classService, Lazy<IAlumniService> alumniService, IAlumniToClassRepo alumniToClassRepo)
        {
            this._classService = classService;
            this._alumniService= alumniService;
            this._repo = alumniToClassRepo;
        }
        public async Task<int> CountAlumniByClassid(int classId)
        {
            var alumniClass = await _classService.Value.GetClassById(classId);
            if(alumniClass == null)
            {
                throw new NotFoundException("class not found with id: "+classId);
            }
            var count = await _repo.CountByCondition(c => c.ClassId == classId && c.Archived == true);
            return count;
        }

        public Task<int> CreateAlumniToClass(AlumniToClass alumniToClass)
        {
            var alumniClass = _classService.Value.GetClassById(alumniToClass.ClassId);
            if (alumniClass == null)
            {
                throw new NotFoundException("class not found with id: " + alumniToClass.ClassId);
            }
            var alumni = _alumniService.Value.GetById(alumniToClass.ClassId);
            if (alumni == null)
            {
                throw new NotFoundException("Alumni not found with id: " + alumniToClass.AlumniId);
            }
            var alumniToClassId = _repo.CreateAsync(alumniToClass);
            return alumniToClassId;
        }

        public async Task DeleteAlumniToClass(int id)
        {
            AlumniToClass alumniToClass = await _repo.GetByIdAsync(c => c.ClassId == id && c.Archived == true);
            if (alumniToClass == null)
            {
                throw new NotFoundException("alumniToClass not found with id: " + id);
            }
            alumniToClass.Archived = false;
            await _repo.UpdateAsync(alumniToClass);
        }

        public async Task<IEnumerable<int>> GetClassIdByAlumniId(int alumniId)
        {
            var classes = await _repo.GetAllByConditionAsync(c => c.AlumniId == alumniId && c.Archived == true);
            var classesId = classes.Select(classes => classes.Id).ToList().Distinct();
            return classesId;
        }

        /* public Task<Alumni> GetAlumniByClassId(int classId)
         {
             var alumni = _alumniService.GetById(classId);
             if (alumni == null)
             {
                 throw new NotFoundException("Alumni not found with id: " + classId);
             }
             return alumni;
         }*/
    }
}
