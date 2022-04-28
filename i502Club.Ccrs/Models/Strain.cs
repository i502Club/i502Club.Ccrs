using i502Club.Ccrs.Enums;
using System;

namespace i502Club.Ccrs.Models
{
    public class Strain 
    {
        public string Name { get; set; }
        public StrainType Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
