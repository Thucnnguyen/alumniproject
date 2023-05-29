using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity;

public class AlumniClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int GradeId { get; set; }
    public virtual Grade Grade { get; set; }
    public virtual ICollection<AlumniToClass> AlumniToClasse { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Archived { get; set; }


}
