using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Telefon
    {
        public int Id { get; set; }

        public int RedniBr { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Polje za broj je obavezno")]
        public string Broj { get; set; }

        public string Lokal { get; set; }

        
        [Display(Name = "Oznaka telefona")]
        public OznakaTelefona OznakaTelefona { get; set; }




    }
}