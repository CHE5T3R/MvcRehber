using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcRehber2.Models
{
    public class user
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        [Required]
        public string userName { get; set; }
        [DisplayName("Password")]
        [Required]
        public string password { get; set; }
        [DisplayName("Confirm Password")]
        [Required]
        public string passwordControl { get; set; }

    }
}