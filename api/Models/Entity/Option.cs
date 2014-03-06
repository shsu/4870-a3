using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Option
    {
        [Key]
        public int OptionID { get; set; }
        
        public String Title { get; set; }

        public Boolean IsActive { get; set; }
    }
}