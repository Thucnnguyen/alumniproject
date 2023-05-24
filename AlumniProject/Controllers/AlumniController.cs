using AlumniProject.Data;
using AlumniProject.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumniController : ControllerBase
    {
        AlumniDbContext db;
        public AlumniController(AlumniDbContext alumniDbContext)
        {
            this.db = alumniDbContext;
        }
        [HttpGet]
        public ActionResult<List<Alumni>> GetAlumni()
        {
            return db.Alumni.ToList();
        }
    }
}
