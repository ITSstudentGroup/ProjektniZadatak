using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class AdreseViewModel
    {
        public List<Mail> Adrese { get; set; }
        public IEnumerable<OznakaMaila> OznakeMaila { get; set; }
    }
}