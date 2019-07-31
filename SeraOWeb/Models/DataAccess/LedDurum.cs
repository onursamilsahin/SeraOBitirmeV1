using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraOWeb.Models.DataAccess
{
    public class LedDurum
    {

        public int Id { get; set; }
        public bool LDurum { get; set; }
        public int SeraId { get; set; }
        public string Led1 { get; set; }
        public string Led2 { get; set; }
    }
}