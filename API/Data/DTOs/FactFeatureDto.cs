using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class FactFeatureDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FactId { get; set; }
        public string FactBullet { get; set; }
    }
}