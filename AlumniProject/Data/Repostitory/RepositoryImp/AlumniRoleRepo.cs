using AlumniProject.Entity;

namespace AlumniProject.Data.Repostitory.RepositoryImp
{
    public class AlumniRoleRepo : RepositoryBase<AlumniRole>, IAlumniRoleRepo
    {
        public AlumniRoleRepo(AlumniDbContext context) : base(context)
        {
        }
    }
}
