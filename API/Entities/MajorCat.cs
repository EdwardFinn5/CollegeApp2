using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class MajorCat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MajorCatId { get; set; }
        public string MajorCatName { get; set; }
        public IList<Major> Majors { get; set; }
    }
}