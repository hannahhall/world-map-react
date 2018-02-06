using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WorldMapApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<Stats> UserStats { get; set; }
    }
}