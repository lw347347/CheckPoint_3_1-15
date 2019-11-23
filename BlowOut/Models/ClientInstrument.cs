using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class ClientInstrument
    {
        public int ClientInstrumentID { get; set; }
        public Client Client { get; set; }
        public Instrument Instrument { get; set; }
    }
}