using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Dto;

public class GradeDTO
{
    public string Code { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public DateTime CreatedAt { get; set; }
}
