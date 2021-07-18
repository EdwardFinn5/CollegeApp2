using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class HsRegisterDto
    {
        [Required]
        // [EmailAddress]
        public string ColUsername { get; set; }

        // [Required]
        public string FirstName { get; set; }

        // [Required]
        public string ClassYear { get; set; }

        // [Required]
        public string HsName { get; set; }

        // [Required]
        public string HsLocation { get; set; }


        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        public string ColUserType { get; set; } = "ColLead";

    }
}