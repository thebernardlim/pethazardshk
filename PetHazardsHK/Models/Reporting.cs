using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHK.Models
{
    public class Reporting
    {
        public int ID { get; set; }
        //public string DistrictID { get; set; }
        public string HazardType { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}
