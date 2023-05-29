using AlumniProject.Entity;

namespace AlumniProject.Data.Repostitory.RepositoryImp;

public class AlumniSchoolRepo : RepositoryBase<AlumniSchool>, IAlumniSchoolRepo
{
    public AlumniSchoolRepo(AlumniDbContext context) : base(context)
    {
    }
}
