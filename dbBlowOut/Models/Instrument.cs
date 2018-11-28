using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dbBlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instrumentID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Condition")]
        public string condition { get; set; }

        [Required]
        [DisplayName("Price")]
        public int price { get; set; }

        [ForeignKey("Client")]
        [DisplayName("Client")]
        public virtual int? clientID { get; set; }
        public virtual Client Client { get; set; }

    }
}