using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniProject.Entity;

public class TagsNew
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string tagName  { get; set; }
    public bool Archived { get; set; }

    public virtual ICollection<NewsTagNew> NewsTagNews { get; set; }
}
