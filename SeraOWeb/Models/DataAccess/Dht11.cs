using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraOWeb.Models.DataAccess
{
    public class Dht11
    {


        public int Id { get; set; }
        public string Sicaklik { get; set; }
        public string HavaNem { get; set; }
        public Nullable<System.DateTime> ETarihi { get; set; }
        public Nullable<int> SeraId { get; set; }

    }
}