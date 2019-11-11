using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NewPrice { get; set; }
        public int UsedPrice { get; set; }
    }
}