using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class TelefoniViewModel
    {
        public List<Telefon> Telefoni { get; set; }
        public IEnumerable<OznakaTelefona> OznakeTelefona { get; set; }
            
    }
}