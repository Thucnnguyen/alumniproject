namespace AlumniProject.Entity;

public class AlumniRole
{
    public int Id { get; set; }
    public int AlumniId { get; set; }
    public int RoleId { get; set; }
    public virtual Alumni Alumni { get; set; }
    public virtual Role Role { get; set; }
}
