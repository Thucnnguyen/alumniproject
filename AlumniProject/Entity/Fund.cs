namespace AlumniProject.Entity;

public class Fund
{
    public int Id { get; set; }
    public int Title { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TargetBalance { get; set; }
    public string BackgroundImage { get; set; }
    public bool Archived { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual School School { get; set; }
}
