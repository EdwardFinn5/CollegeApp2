using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class CollegeMajor
    {
        public int CollegeNum { get; set; }
        public ColUser ColUser { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}