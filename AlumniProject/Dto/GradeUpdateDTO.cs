using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Dto;

public class GradeUpdateDTO
{
    [Required(ErrorMessage = "Code is required")]
    public string Code { get; set; }
    [Required(ErrorMessage = "StartYear is required")]
    public int StartYear { get; set; }
    [Required(ErrorMessage = "EndYear is required")]
    public int EndYear { get; set; }
}
