using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OsobaUredjivanje
    {
        public OsobaOsnovni Osoba { get; set; }
        public IEnumerable<Pol> Pol { get; set; }


    }
}