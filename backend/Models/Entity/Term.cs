using backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Term
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public String Description { get; set; }

        public Boolean IsActive { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}