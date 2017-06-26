using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{

  
    public class registration
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
            [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password not matched")]
            public string ConfirmPassword { get; set; }
            [Required]
            [Display(Name = "Email Address")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [Display(Name = "Phone Number")]
            public string Phone_no{ get; set; }
        [Display(Name = "Log in as")]
        public int type_id{ get; set; }
        
        //[ForeignKey("type_id")]
        //public virtual typedef typedefs { get; set; }


        public registration_tb User
            {
                get
                {
                    var tmp = new registration_tb() {  Email = this.Email, Password = this.Password, Phone_no = this.Phone_no, Username = this.Username,type_id=this.type_id };
                    return tmp;
                }
            }
        }
    
}