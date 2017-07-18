using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class crop
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Crop name is required")]

        public string crop_name { get; set; }
       // [Required(ErrorMessage = "Description is required")]

       
        [Required(ErrorMessage = "Topography is required")]

        public int topography_id { get; set; }
        
        [ForeignKey ("topography_id")]
        public virtual topography topographys { get; set; }
        //  [Required(ErrorMessage = "Season is required")]
        public int season_id { get; set; }
        [ForeignKey("season_id")]

        public virtual seasondef Season { get; set; }
    }

    public class CropViewModel
    {
        public int id { get; set; }
        public string crop_name { get; set; }
        public int topography_id { get; set; }
        public string topography_Name { get; set; }

        public int season_id { get; set; }
        public string season_Name { get; set; }

    }

}