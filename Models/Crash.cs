﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class Crash
    {
        [Key]
        public int CRASH_ID { get; set; }
        public string CRASH_DATETIME { get; set; }
        public string ROUTE { get; set; }
        public string MILEPOINT { get; set; }
        public string LAT_UTM_Y { get; set; }
        public string LONG_UTM_X { get; set; }
        public string MAIN_ROAD_NAME { get; set; }
        public string CITY { get; set; }
        public string COUNTY_NAME { get; set; }
        public string CRASH_SEVERITY_ID { get; set; }
        public string WORK_ZONE_RELATED { get; set; }
        public string PEDESTRIAN_INVOLVED { get; set; }
        public string BICYCLIST_INVOLVED { get; set; }
        public string MOTORCYCLE_INVOLVED { get; set; }
        public string IMPROPER_RESTRAINT { get; set; }
        public string UNRESTRAINED { get; set; }
        public string DUI { get; set; }
        public string INTERSECTION_RELATED { get; set; }
        public string WILD_ANIMAL_RELATED { get; set; }
        public string DOMESTIC_ANIMAL_RELATED { get; set; }
        public string OVERTURN_ROLLOVER { get; set; }
        public string COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public string TEENAGE_DRIVER_INVOLVED { get; set; }
        public string OLDER_DRIVER_INVOLVED { get; set; }
        public string NIGHT_DARK_CONDITION { get; set; }
        public string SINGLE_VEHICLE { get; set; }
        public string DISTRACTED_DRIVING { get; set; }
        public string DROWSY_DRIVING { get; set; }
        public string ROADWAY_DEPARTURE { get; set; }
    }
}
