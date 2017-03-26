using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OsobaNovaViewModel
    {
        public OsobaNova Osoba { get; set; }
        public IEnumerable<OznakaTelefona> OznakeTelefona { get; set; }
        public IEnumerable<OznakaMaila> OznakeMaila { get; set; }
        public IEnumerable<OznakaPostanskeAdrese> OznakePostanskeAdrese { get; set; }
        public IEnumerable<Pol> Pol { get; set; }


    }
}