using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Major
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MajorId { get; set; }
        
        public string MajorName { get; set; }
        
        public int MajorCatId { get; set; }
        
        public MajorCat MajorCat { get; set; }

        public ICollection<CollegeMajor> CollegeMajors { get; set; }
    }
}