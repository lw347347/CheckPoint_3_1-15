using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class UpdateData
    {
        // Client side of things
        [Key]
        public int? ClientID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"\d{5}$", ErrorMessage = "Invalid Zip Code")]
        public int Zipcode { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please use a valid email.")]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Please use valid # in (XXX) XXX-XXXX format")]
        public string PhoneNumber { get; set; }

        // Instrument side of things
        [Key]
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public bool New { get; set; }
    }
}