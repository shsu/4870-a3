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
        public int ChoiceID { get; set; }

        //public DateTime CreateDate { get; set; }

        [Required]
        public String StudentNumber { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public int TermCode { get; set; }

        [Required]
        public int FirstOptionChoiceID { get; set; }

        [Required]
        public int SecondOptionChoiceID { get; set; }

        [Required]
        public int ThirdOptionChoiceID { get; set; }

        [Required]
        public int ForthOptionChoiceID { get; set; }


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