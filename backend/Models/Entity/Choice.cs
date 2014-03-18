using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backend.Models.Entity
{
    public class Choice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public DateTime CreateDate { get; set; }

        [Required]
        public String StudentNumber { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        [ForeignKey("Term")]
        public int TermId { get; set; }

        [Required]
        [ForeignKey("FirstOptionChoice")]
        public int FirstOptionChoiceId { get; set; }

        [Required]
        [ForeignKey("SecondOptionChoice")]
        public int SecondOptionChoiceId { get; set; }

        [Required]
        [ForeignKey("ThirdOptionChoice")]
        public int ThirdOptionChoiceId { get; set; }

        [Required]
        [ForeignKey("ForthOptionChoice")]
        public int ForthOptionChoiceId { get; set; }


        /* ==============================
         * Navigational Properties
         * ==============================
         */
        
       
        public virtual Term Term { get; set; }
        
        public virtual Option FirstOptionChoice { get; set; }

        public virtual Option SecondOptionChoice { get; set; }

        public virtual Option ThirdOptionChoice { get; set; }

        public virtual Option ForthOptionChoice { get; set; }

    }
}