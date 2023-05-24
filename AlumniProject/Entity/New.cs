using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity;

public class New
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    [StringLength(int.MaxValue)]
    public string Content { get; set; }
    public string NewsImageUrl { get; set; }
    public string IsPublic { get; set; }
    public int AlumniId { get; set; }
    public int SchoolId { get; set; }
    public bool Archived { get; set; }


    public virtual Alumni Alumni { get; set; }
    public virtual School School { get; set; }

    public virtual ICollection<NewsTagNew> NewsTagNews { get; set; }
}
