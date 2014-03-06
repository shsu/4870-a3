using api.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Term
    {
        [Key]
        public int Code { get; set; }

        public String Description { get; set; }

        public Boolean IsActive { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}