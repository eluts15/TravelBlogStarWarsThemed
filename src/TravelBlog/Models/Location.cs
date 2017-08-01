using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {   
        [Key]
        public int LocationId { get; set; }
        public string Planet { get; set; }
        public string GalacticRegion { get; set; }
        [Required]
        public string Biome { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

    }
}
