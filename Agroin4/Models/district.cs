﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class district
    {
        public int id { get; set; }
        [Display(Name = "District Name")]
        public string district_name { get; set; }
        public virtual ICollection<shop>shops { get; set; }


    }
}