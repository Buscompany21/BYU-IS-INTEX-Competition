using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }
        [MaxLength(50)]
        public string CRASH_DATETIME { get; set; }
        [MaxLength(75)]
        public string ROUTE { get; set; }
        [MaxLength(75)]
        public string MILEPOINT { get; set; }
        [MaxLength(75)]
        public string LAT_UTM_Y { get; set; }
        [MaxLength(75)]
        public string LONG_UTM_X { get; set; }
        [MaxLength(75)]
        public string MAIN_ROAD_NAME { get; set; }
        [MaxLength(75)]
        public string CITY { get; set; }
        [MaxLength(75)]
        public string COUNTY_NAME { get; set; }
        [MaxLength(75)]
        public string CRASH_SEVERITY_ID { get; set; }
        [MaxLength(75)]
        public string WORK_ZONE_RELATED { get; set; }
        [MaxLength(75)]
        public string PEDESTRIAN_INVOLVED { get; set; }
        [MaxLength(75)]
        public string BICYCLIST_INVOLVED { get; set; }
        [MaxLength(75)]
        public string MOTORCYCLE_INVOLVED { get; set; }
        [MaxLength(75)]
        public string IMPROPER_RESTRAINT { get; set; }
        [MaxLength(75)]
        public string UNRESTRAINED { get; set; }
        [MaxLength(75)]
        public string DUI { get; set; }
        [MaxLength(75)]
        public string INTERSECTION_RELATED { get; set; }
        [MaxLength(75)]
        public string WILD_ANIMAL_RELATED { get; set; }
        [MaxLength(75)]
        public string DOMESTIC_ANIMAL_RELATED { get; set; }
        [MaxLength(75)]
        public string OVERTURN_ROLLOVER { get; set; }
        [MaxLength(75)]
        public string COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        [MaxLength(75)]
        public string TEENAGE_DRIVER_INVOLVED { get; set; }
        [MaxLength(75)]
        public string OLDER_DRIVER_INVOLVED { get; set; }
        [MaxLength(75)]
        public string NIGHT_DARK_CONDITION { get; set; }
        [MaxLength(75)]
        public string SINGLE_VEHICLE { get; set; }
        [MaxLength(75)]
        public string DISTRACTED_DRIVING { get; set; }
        [MaxLength(75)]
        public string DROWSY_DRIVING { get; set; }
        [MaxLength(75)]
        public string ROADWAY_DEPARTURE { get; set; }
        
    }
}
