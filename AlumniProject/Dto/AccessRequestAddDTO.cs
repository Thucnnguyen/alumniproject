using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Dto
{
    public class AccessRequestAddDTO
    {
        [Required(ErrorMessage = "FullName is required"), MaxLength(255)]
        public string FullName { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; }
        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "AlumniClassId is required")]
        public int AlumniClassId { get; set; }
        
    }
}
