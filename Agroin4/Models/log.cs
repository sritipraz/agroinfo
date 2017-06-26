using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class log
    {
        public int log_id { get; set; }
        public int farmer_id { get; set; }
        public int qa_id { get; set; }
        public int crop_id { get; set; }
        public char quality { get; set; }
        public int district_id { get; set; }
        public int production_quantity { get; set; }
        public int production_area { get; set; }
        public int year { get; set; }
        public int season_id { get; set; }

    }
}