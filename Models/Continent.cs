using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldMapApi.Models
{
    public class Continent
    {
        [Key]
        public int ContinentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public virtual ICollection<SubRegion> Regions { get; set; }

    }
}