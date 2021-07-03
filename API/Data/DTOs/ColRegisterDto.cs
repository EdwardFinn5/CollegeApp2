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
    }
}