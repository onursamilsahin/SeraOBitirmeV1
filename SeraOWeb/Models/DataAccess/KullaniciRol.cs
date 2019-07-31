using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraOWeb.Models.DataAccess
{
    public class KullaniciRol
    {

        public int Id { get; set; }

        public int RolId { get; set; }
        public int  KullaniciId { get; set; }
    }
}