using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class PostanskaAdresa
    {
        public int Id { get; set; }

        public int RedniBr { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Polje za adresu je obavezno")]
        public string Adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za poštanski broj je obavezno")]
        [Display(Name ="Poštanski broj")]
        public string PostanskiBroj { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za grad je obavezno")]
        public string Grad { get; set; }

        
        [Display(Name = "Oznaka adrese")]
        public OznakaPostanskeAdrese OznakaPostanskeAdrese { get; set; }

    }
}