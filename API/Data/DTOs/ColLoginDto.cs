using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ColLoginDto
    {
        [Required]
        public string ColUserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}