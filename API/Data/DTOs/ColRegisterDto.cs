using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ColRegisterDto
    {
        [Required]
        public string ColUsername { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        public string ColUserType { get; set; } = "College";
        [Required]
        public string CollegeName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string CollegeLocation { get; set; } = "Des Moines";
        [Required]
        public int CollegeEnrollment { get; set; }
    }
}