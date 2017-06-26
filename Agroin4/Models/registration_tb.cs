using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class registration_tb
    {
        public int id { get; set; }


        public string Username { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }


        public string Phone_no { get; set; }
        public int type_id { get; set; }
        [ForeignKey("type_id")]
        public virtual typedef typedefs { get; set; }
    }
}