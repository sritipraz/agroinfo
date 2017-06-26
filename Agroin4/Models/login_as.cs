using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class login_as
    {
       
    public int id { get; set; }
        [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            [MinLength(6, ErrorMessage = "Password must be of atleast 6 characters.")]
            public string Password { get; set; }

        public registration_tb User
        {
            get
            {
                var tmp = new registration_tb() {Password = this.Password, Username = this.Username };
                return tmp;
            }
        }

    }
}