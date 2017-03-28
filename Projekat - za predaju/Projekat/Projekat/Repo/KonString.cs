using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projekat.Repo
{
    public class KonString
    {
        public static readonly string Konekcija = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
    }
}