using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Code { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public string SchoolId { get; set; }
    public bool Archived { get; set; }

    public virtual School School { get; set; }
}
