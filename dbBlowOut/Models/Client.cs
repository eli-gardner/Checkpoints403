using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dbBlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clientID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Street Address")]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("City")]
        public string city { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("State")]
        public string state { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("ZIP Code")]
        [RegularExpression(@"^\d{5}([\-]\d{4})?$", ErrorMessage = "Enter a valid ZIP Code")]
        public string zip { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        [Required]
        [StringLength(60)]
        [DisplayName("Email Address")]
        public string email { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid Phone Number (xxx) xxx-xxxx")]
        public string phone { get; set; }
    }
}