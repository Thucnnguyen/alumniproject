using AlumniProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlumniProject.Data.Repostitory.RepositoryImp;

public class AlumniRepo : RepositoryBase<Alumni> , IAlumniRepo
{
    public AlumniRepo(AlumniDbContext alumniDbContext):base(alumniDbContext)
    {

    }

    public Task<Alumni> GetAlumniByEmail(string email)
    {
        var existAlumni = FindOneByCondition(a => a.Email == email);
        return existAlumni;
    }
    //private readonly AlumniDbContext _context;

    //public AlumniRepo(AlumniDbContext context)
    //{
    //    _context = context;
    //}

    //public async Task<bool> AddNewAlumni(Alumni alumni)
    //{
    //    await _context.Alumni.AddAsync(alumni);
    //    await _context.SaveChangesAsync();
    //    return true;
    //}

    //public async Task<bool> DeleteAlumni(int id)
    //{
    //    var existingAlumni = await GetAlumniById(id);
    //    if (existingAlumni == null)
    //    {
    //        return false;
    //    }
    //    existingAlumni.Archived = false;
    //    await _context.SaveChangesAsync();
    //    return true;
    //}

    //public async Task<IEnumerable<Alumni>> GetAllAlumnis(int pageNo, int Pagesize)
    //{
    //    var skipAmount = (pageNo - 1)*Pagesize;
    //    var alumnis = await _context.Alumni
    //        .Where(alum => alum.Archived == true)
    //        .OrderBy(alum => alum.Id)
    //        .Skip(skipAmount)
    //        .Take(Pagesize)
    //        .ToListAsync();
    //    return alumnis;
    //}

    //public async Task<Alumni?> GetAlumniById(int id)
    //{
    //    var existingAlumni = await _context.Alumni.FirstOrDefaultAsync(alum => alum.Id == id && alum.Archived == true);
    //    return existingAlumni;
    //}

    //public async Task<Alumni?> Update(Alumni updateAlumni)
    //{
    //    var existingAlumni = await GetAlumniById(updateAlumni.Id);
    //    if(existingAlumni == null)
    //    {
    //        return null;
    //    }

    //    existingAlumni.Bio = updateAlumni.Bio;
    //    existingAlumni.FullName = updateAlumni.FullName;
    //    existingAlumni.Avatar_url = updateAlumni.Avatar_url;
    //    existingAlumni.CoverImage_url = updateAlumni.CoverImage_url;
    //    existingAlumni.Email = updateAlumni.Email;
    //    existingAlumni.Phone = updateAlumni.Phone;
    //    existingAlumni.PhonePublicity = updateAlumni.PhonePublicity;
    //    existingAlumni.FaceBook_url = updateAlumni.FaceBook_url;
    //    existingAlumni.FaceBookPublicity = updateAlumni.FaceBookPublicity;
    //    existingAlumni.DateOfBirth = updateAlumni.DateOfBirth;

    //    await _context.SaveChangesAsync();

    //    return existingAlumni;
    //}
}
