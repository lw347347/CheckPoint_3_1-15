using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut.DALL
{
    public class RentalsContext : DbContext
    {
        public RentalsContext()
            : base("RentalsContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        public System.Data.Entity.DbSet<BlowOut.Models.ClientInstrument> ClientInstruments { get; set; }
    }
}