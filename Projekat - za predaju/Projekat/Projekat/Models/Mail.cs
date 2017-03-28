using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Mail
    {
        public int Id { get; set; }

        public int RedniBr { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Polje za e-mail je obavezno")]  
        [Display(Name = "E-Mail")]  
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage ="Neispravno uneta e-mail adresa")]
        public string Adresa { get; set; }


        [Display(Name = "Oznaka mail-a")]
        public OznakaMaila OznakaMaila { get; set; }
    }
}