using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity;

public class AccessRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FullName { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string RequestStatus { get; set; }
    public int AlunmniId { get; set; }
    public int AlumniClassId { get; set; }
    public bool Archived { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual AlumniClass AlumniClass { get; set; }
    public virtual Alumni Alumni { get; set; }
}
