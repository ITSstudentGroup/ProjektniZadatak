using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class KorisnikIzmenaNoviViewModel
    {
        public KorisnikIzmenaNovi Korisnik { get; set; }

        public IEnumerable<Uloga> SveUloge { get; set; }



    }
}