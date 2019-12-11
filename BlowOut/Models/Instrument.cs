using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public bool New { get; set; }
        public int? ClientID { get; set; }
    }
}