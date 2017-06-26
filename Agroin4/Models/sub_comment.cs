using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class sub_comment
    {
        public int sub_id { get; set; }
        public int comment_id { get; set; }
        public int user_id { get; set; }
        public string comment { get; set; }
        public bool status { get; set; }

    }
}