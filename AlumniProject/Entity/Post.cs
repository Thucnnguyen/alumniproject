using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniProject.Entity;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string content { get; set; }
    public int AlumniId {get; set; }
    public bool IsPublicSchool { get; set; }
    public bool IsPublic { get; set; }
    public bool Archived { get; set; }

    public virtual Alumni Alumni { get; set; }
}
