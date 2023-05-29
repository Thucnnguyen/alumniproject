using AlumniProject.Entity;

namespace AlumniProject.Data.Repostitory;

public interface IAlumniRepo : IRepositoryBase<Alumni>
{
    Task<Alumni> GetAlumniByEmail(string email);
}
