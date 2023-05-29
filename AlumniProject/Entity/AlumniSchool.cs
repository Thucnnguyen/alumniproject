using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity
{
    public class AlumniSchool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int AlumniId { get; set; }
        public int SchoolId { get; set; }

        public virtual Alumni Alumni { get; set; }
        public virtual School School { get; set; }  
    }
}
