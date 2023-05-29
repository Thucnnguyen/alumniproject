using AlumniProject.Entity;

namespace AlumniProject.Data.Repostitory.RepositoryImp;

public class NewRepo : RepositoryBase<New>, INewRepo
{
    public NewRepo(AlumniDbContext context) : base(context)
    {
    }
}
