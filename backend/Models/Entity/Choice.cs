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
        public int TermId { get; set; }

        [Required]
        public int FirstOptionChoiceId { get; set; }

        [Required]
        public int SecondOptionChoiceId { get; set; }

        [Required]
        public int ThirdOptionChoiceId { get; set; }

        [Required]
        public int ForthOptionChoiceId { get; set; }


        /* ==============================
         * Navigational Properties
         * ==============================
         */
        [ForeignKey("TermId")]
        [InverseProperty("Id")]
        public virtual Term Term { get; set; }

        [ForeignKey("FirstOptionChoiceId")]
        [InverseProperty("Id")]
        public virtual Option FirstOptionChoice { get; set; }

        [ForeignKey("SecondOptionChoiceId")]
        public virtual Option SecondOptionChoice { get; set; }

        [ForeignKey("ThirdOptionChoiceId")]
        [InverseProperty("Id")]
        public virtual Option ThirdOptionChoice { get; set; }

        [ForeignKey("ForthOptionChoiceId")]
        [InverseProperty("Id")]
        public virtual Option ForthOptionChoice { get; set; }

    }
}