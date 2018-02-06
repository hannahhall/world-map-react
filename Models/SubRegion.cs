using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldMapApi.Models
{
    public class SubRegion
    {
        [Key]
        public int SubRegionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ContinentId { get; set; }

        public Continent Continent { get; set; }

        public virtual ICollection<Country> Countries { get; set; }




    }
}