using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHKWebApp.Models
{
    public class Reporting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //public string DistrictID { get; set; }
        public string HazardType { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public DateTime ReportedDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
