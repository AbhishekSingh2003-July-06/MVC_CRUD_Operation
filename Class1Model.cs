using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationRevisionCRUD.Models
{
    public class Class1Model
    {
        public int id { get; set; }
        [Required (ErrorMessage ="Pls enter ur name")]

        public string name { get; set; }
        [Required]
        public string email_id { get; set; }
        [Required]
        public string contact_No { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public decimal? salary { get; set; }
     
    }
}