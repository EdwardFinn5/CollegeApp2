using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ColPhotoDto
    {
        [Key]
        public int ColPhotoId { get; set; }
        public string ColUrl { get; set; }
        public string HsStudentUrl { get; set; }
        public string AdminUrl { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMainCol { get; set; } = false;
        public bool IsMainHs { get; set; } = false;
        public bool IsMainAdmin { get; set; } = false;
        public string PublicId { get; set; }
    }
}